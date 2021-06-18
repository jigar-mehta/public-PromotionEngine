namespace PromotionEngine.Service.AutoPromotion.Promotion
{
	public class OrderItem
	{
		public Items Item { get; set; }
		public int Quantity { get; set; }
		public bool PromoApplied { get; set; }
		public double Price { get; set; }
	}
}
