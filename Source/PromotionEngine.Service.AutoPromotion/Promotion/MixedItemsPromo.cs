using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Service.AutoPromotion.Promotion
{
	public class MixedItemsPromo : IMiscPromotion
	{
		List<Items> productsInPromo = new List<Items> { Items.C, Items.D };
		private readonly double offerPrice = 30;  //per offer group, in this case 1 item each
		private readonly int multiplier = 1;

		public async Task ApplyMixedProductPromotionAsync(List<OrderItem> orderItems)
		{
			var itemListForPromo = orderItems.Where(w => w.Quantity > 0).Select(s => s.Item).ToList();
			if (itemListForPromo.Intersect(productsInPromo).Count() == productsInPromo.Count)
			{
				var maxQuantityForOffer = orderItems.Select(d => d.Quantity).ToList().Min();
				orderItems.ForEach(f =>
				{
					f.PromoApplied = true;
					f.Price = 0;
					f.Quantity -= maxQuantityForOffer;
				});

				orderItems.Last().Price = offerPrice * maxQuantityForOffer;
			}
		}

	}
}
