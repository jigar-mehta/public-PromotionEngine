using PromotionEngine.Service.AutoPromotion.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PromotionEngine.Service.AutoPromotion_uTest.Promotion
{
	public class MixedItemsPromoTest
	{
		private readonly MixedItemsPromo myMixedItemsPromo;

		public MixedItemsPromoTest()
		{
			myMixedItemsPromo = new MixedItemsPromo();
		}

		[Fact]
		public async Task TestApplyMixedProductPromotionAsync_WhenItemsHaveDifferentQuantity_TheCommonMaxQuantityIsTakenForOffer()
		{
			var order = new List<OrderItem>();
			order.Add(new OrderItem { Item = Items.C, Quantity = 2 });
			order.Add(new OrderItem { Item = Items.D, Quantity = 3 });

			await myMixedItemsPromo.ApplyMixedProductPromotionAsync(order);

			Assert.Equal(0, order[0].Price);
			Assert.Equal(0, order[0].Quantity);
			Assert.Equal(60, order[1].Price);
			Assert.Equal(1, order[1].Quantity);
		}

		[Fact]
		public async Task TestApplyMixedProductPromotionAsync_WhenItemsHaveQuantityAs0_OfferDoesntApply()
		{
			var order = new List<OrderItem>();
			order.Add(new OrderItem { Item = Items.C, Quantity = 2, Price = 100 });
			order.Add(new OrderItem { Item = Items.D, Quantity = 0, Price = 300 });

			await myMixedItemsPromo.ApplyMixedProductPromotionAsync(order);

			Assert.Equal(100, order[0].Price);
			Assert.Equal(2, order[0].Quantity);
			Assert.Equal(300, order[1].Price);
			Assert.Equal(0, order[1].Quantity);
		}

		[Fact]
		public async Task TestApplyMixedProductPromotionAsync_WhenNotAllItemForOffersAreAvailable_OfferDoesntApply()
		{
			var order = new List<OrderItem>();
			order.Add(new OrderItem { Item = Items.B, Quantity = 2, Price = 100 });
			order.Add(new OrderItem { Item = Items.D, Quantity = 6, Price = 300 });

			await myMixedItemsPromo.ApplyMixedProductPromotionAsync(order);

			Assert.Equal(100, order[0].Price);
			Assert.Equal(2, order[0].Quantity);
			Assert.Equal(300, order[1].Price);
			Assert.Equal(0, order[1].Quantity);
		}

	}
}
