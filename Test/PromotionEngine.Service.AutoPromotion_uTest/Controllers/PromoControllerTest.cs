using PromotionEngine.Service.AutoPromotion.Controllers;
using PromotionEngine.Service.AutoPromotion.Promotion;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PromotionEngine.Service.AutoPromotion_uTest.Controllers
{
    public class PromoControllerTest
    {
        private readonly PromoController myPromoController;

        public PromoControllerTest()
        {
            myPromoController = new PromoController(new PromoFactory());
        }

        [Theory]
        [InlineData(1, 1, 1, 0, 100)]
        [InlineData(5, 5, 1, 0, 370)]
        [InlineData(3, 5, 1, 1, 280)]
        public async Task TestGetFinalPrice(int noOfA, int noOfB, int noOfC, int noOfD, double expected)
        {
            var order = new Dictionary<string, int>();
            order.Add("A", noOfA);
            order.Add("B", noOfB);
            order.Add("C", noOfC);
            order.Add("D", noOfD);

            var result = await myPromoController.GetFinalPrice(order);

            Assert.Equal(expected, result);
        }

    }
}
