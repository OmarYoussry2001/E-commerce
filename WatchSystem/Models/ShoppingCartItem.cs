namespace WatchSystem.Models
{
    public class ShoppingCartItem
    {
        public Guid ShoppingCartItemID { get; set; }
        public string ItemName { get; set; } = "";
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = "";
        public int Qty { get; set; }
        public decimal? Total { get; set; }
    }
}
