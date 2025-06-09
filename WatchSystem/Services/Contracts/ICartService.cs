using BL.DTO.Entities;
using WatchSystem.Models;

namespace WatchSystem.Services.Contracts
{
    public interface ICartService
    {
        ShoppingCartIGeneral GetOrCreateCart();
        void AddToCart(Guid itemId);
        void SaveCart(ShoppingCartIGeneral cart);
        List<SalesInvoiceItemDto> MapCartItemsToInvoiceItems(ShoppingCartIGeneral shoppingCartIGeneral);
    }
}
