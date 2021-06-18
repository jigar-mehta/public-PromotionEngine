using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotionEngine.Service.AutoPromotion.Promotion
{
	public interface IMiscPromotion
	{
		public Task ApplyMixedProductPromotionAsync(List<OrderItem> orderItems);
	}
}
