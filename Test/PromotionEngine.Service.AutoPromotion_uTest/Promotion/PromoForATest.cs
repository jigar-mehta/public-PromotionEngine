using PromotionEngine.Service.AutoPromotion.Promotion;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PromotionEngine.Service.AutoPromotion_uTest.Promotion
{
	public class PromoForATest
	{
		private readonly PromoForA myPromoForA;

		public PromoForATest()
		{
			myPromoForA = new PromoForA();
		}

		[Fact]
		public async Task TestApplyMixedProductPromotionAsync_WhenItemsQuantityIsLessThanNeededForOffer_ThePriceOfItemIsSetWithoutOffer()
		{
			var order = new OrderItem { Item = Items.A, Quantity = 2 };

			await myPromoForA.ApplyProductPromotionAsync(order);

			Assert.Equal(100, order.Price);
			Assert.False(order.PromoApplied);
		}

		[Fact]
		public async Task TestApplyMixedProductPromotionAsync_WhenItemsQuantityIsMoreThanNeededForOffer_TheOfferIsAppliedOnEligibeQuantity()
		{
			var order = new OrderItem { Item = Items.A, Quantity = 7 };

			await myPromoForA.ApplyProductPromotionAsync(order);

			Assert.Equal(310, order.Price);
			Assert.True(order.PromoApplied);
		}
	}
}
