using DAL.Contracts.Repositories.Generic;
using Domains.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts.Repositories.Custom
{
    public interface IItemRepository : IRepository<VwItem>
    {
        public IEnumerable<VwItem> GetSpecialOffers();
        public IEnumerable<VwItem> GetNewItems();
        public IEnumerable<VwItem> GetRelatedItems(Guid Id);
        public IEnumerable<VwItem> GetAllItems();
        public IEnumerable<VwItem> GetBestSellers();
        public IEnumerable<VwItem> GetFeaturedProducts();
    }
}
