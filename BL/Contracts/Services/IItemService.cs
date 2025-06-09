using BL.DTO.Entities;
using BL.DTO.Views;
using DAL.Models;
using Domains.Entities;
using Domains.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts.Services
{
    public interface IItemService : IBaseService<TbItem, ItemDto>
    {
        public new Task<bool> Save(ItemDto dto, Guid userId);
        public bool IncrementSoldCount(IEnumerable<SoldItemDto> soldItems, Guid userId);
        public IEnumerable<VwItemDto> GetSpecialOffers();
        public IEnumerable<VwItemDto> GetNewItems();
        public IEnumerable<VwItemDto> GetRelatedItems(Guid Id);
        public IEnumerable<VwItemDto> GetAllItems();
        public IEnumerable<VwItemDto> GetBestSellers();
        public IEnumerable<VwItemDto> GetFeaturedProducts();
        public VwItemDto Find(Guid id);
        public IEnumerable<VwItemWithTypeNameDto> GetItemsWithTypeName();
        public PaginatedDataModel<VwItemWithTypeNameDto> GetAllItemsByPagination(
         int pageNumber = 1,
         int pageSize = 10,
         string? searchTerm = null,
         string? orderBy = null);
    }
}
