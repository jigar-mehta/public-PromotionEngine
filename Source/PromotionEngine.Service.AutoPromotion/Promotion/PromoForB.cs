using System.Threading.Tasks;

namespace PromotionEngine.Service.AutoPromotion.Promotion
{
    class PromoForB : IPromotion
    {
        private readonly double itemPrice = 30;    //per item
        private readonly double offerPrice = 45;  //per offer group, in this case 2items
        private readonly int multiplier = 2;

        public async Task ApplyProductPromotionAsync(OrderItem orderItem)
        {
            int noOfItems = orderItem.Quantity;

            var singleQuantity = multiplier == 1 && noOfItems == multiplier;
            var promotionApplied = false;
            var totalPrice = 0.0;

            while (noOfItems != 0)
            {
                if (noOfItems < multiplier)
                {
                    totalPrice += noOfItems * itemPrice;
                    noOfItems /= multiplier;
                }
                else
                {
                    totalPrice += (noOfItems / multiplier) * offerPrice;
                    noOfItems %= multiplier;
                    promotionApplied = true;
                }
            }

            orderItem.Price = totalPrice;
            orderItem.PromoApplied = promotionApplied && !singleQuantity;
        }
    }
}
