using System;

namespace PromotionEngine.Service.AutoPromotion.Promotion
{
    public class PromoFactory : IPromoFactory
    {
        public IPromotion CreateInstance(Items items)
        {
            switch (items)
            {
                case Items.A: return new PromoForA();
                case Items.B: return new PromoForB();
                case Items.C: return new PromoForC();
                case Items.D: return new PromoForD();
                default: return (IPromotion)null;
            }
        }

		public IMiscPromotion CreateMiscPromoInstance()
		{
            return new MixedItemsPromo();
		}
	}
}
