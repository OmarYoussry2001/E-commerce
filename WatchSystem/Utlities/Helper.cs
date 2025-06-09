namespace WatchSystem.Utlities
{
    public static class Helper
    {
        public static decimal CalculateDiscount(decimal? price  , decimal? DiscountPercentage)
        {

            return (decimal)(price - (price * (DiscountPercentage/100)));

        }

    }
}
