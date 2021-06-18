using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotionEngine.Service.AutoPromotion.Promotion
{
    public interface IPromotion
    {
        public Task ApplyProductPromotionAsync(OrderItem orderItem);
    }
}
