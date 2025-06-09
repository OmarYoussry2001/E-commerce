namespace WatchSystem.Models
{
    public class ShoppingCartIGeneral
    {
        public ShoppingCartIGeneral()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public decimal? Total { get; set; }

    }
}
