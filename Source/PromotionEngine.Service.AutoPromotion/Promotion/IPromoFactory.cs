namespace PromotionEngine.Service.AutoPromotion.Promotion
{
    public interface IPromoFactory
    {
        public IPromotion CreateInstance(Items items);

        public IMiscPromotion CreateMiscPromoInstance();
    }

    public enum Items
    {
        A,B,C,D,E,F
    }
}
