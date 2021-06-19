using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Service.AutoPromotion.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Service.AutoPromotion.Controllers
{
    [ApiController]
    public class PromoController : ControllerBase
    {
        private readonly IPromoFactory myPromoFactory;
        private IPromotion myPromotion;
        private IMiscPromotion myMiscPromotion;

        public PromoController(IPromoFactory promoFactory)
        {
            myPromoFactory = promoFactory;
        }

        [HttpGet]
        [Route("api/promo")]
        public async Task<double> GetFinalPrice([FromBody] Dictionary<string, int> cartOrder)
        {
            List<OrderItem> order = new List<OrderItem>();
            foreach (var item in cartOrder)
            {
                var orderItem = new OrderItem { Item = (Items)Enum.Parse(typeof(Items), item.Key), Quantity = item.Value };

                myPromotion = myPromoFactory.CreateInstance(orderItem.Item);
                if (myPromotion != null)
                    await myPromotion.ApplyProductPromotionAsync(orderItem);

                order.Add(orderItem);
            }

            myMiscPromotion = myPromoFactory.CreateMiscPromoInstance();
            await myMiscPromotion.ApplyMixedProductPromotionAsync(order.Where(w => w.PromoApplied == false).ToList());

            //for remaining items which are not eligible for offer
            order.Where(w => w.PromoApplied == false).ToList().ForEach(async remainingItem => 
                {
                    myPromotion = myPromoFactory.CreateInstance(remainingItem.Item);
                    await myPromotion.ApplyProductPromotionAsync(remainingItem);
                });

            return order.Sum(s => s.Price);
        }
    }
}
