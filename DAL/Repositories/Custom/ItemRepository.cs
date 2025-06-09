using DAL.ApplicationContext;
using DAL.Contracts.Repositories.Custom;
using DAL.Repositories.Generic;
using Domains.Views;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Custom
{
    public class ItemRepository : Repository<VwItem>, IItemRepository

    {
        public ItemRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
        public IEnumerable<VwItem> GetSpecialOffers()
        {
            try
            {
                return DbSet.AsNoTracking().OrderByDescending(x => x.DiscountPercent).Take(5).ToList();
            }
            catch (Exception ex)
            {
                HandleException(nameof(GetAll), "An error occurred while retrieving special offers.", $"Error occurred while retrieving all entities of type {typeof(VwItem).Name}.", ex);
                throw; // Rethrow the exception after logging

            }
        }
        public IEnumerable<VwItem> GetNewItems()
        {
            try
            {
                return DbSet.AsNoTracking().OrderByDescending(x => x.CreatedDateUtc).Take(5).Distinct().ToList();
            }
            catch (Exception ex)
            {
                HandleException(nameof(GetAll), "An error occurred while retrieving new items.", $"Error occurred while retrieving all entities of type {typeof(VwItem).Name}.", ex);
                throw; // Rethrow the exception after logging
            }
        }
        public IEnumerable<VwItem> GetRelatedItems(Guid Id)
        {

            try
            {
                var item = Find(x => x.Id == Id);
                return DbSet.AsNoTracking()
                    .Where(x => x.Price >= item.Price - 100 && x.Price <= item.Price + 100
                                && x.Id != Id)
                    .OrderBy(x => Guid.NewGuid())
                    .Take(6)
                    .Distinct()  
                    .ToList();
            }
            catch (Exception ex)
            {
                HandleException(nameof(GetAll), "An error occurred while retrieving related items.", $"Error occurred while retrieving all entities of type {typeof(VwItem).Name}.", ex);
                throw; // Rethrow the exception after logging
            }
        }
        public IEnumerable<VwItem> GetAllItems()
        {
            try
            {
              return DbSet
             .AsNoTracking()
             .OrderBy(x => Guid.NewGuid())
             .ToList();
            }
            catch (Exception ex)
            {
                HandleException(nameof(GetAll), "An error occurred while retrieving all items.", $"Error occurred while retrieving all entities of type {typeof(VwItem).Name}.", ex);
                throw; // Rethrow the exception after logging
            }
        }
        public IEnumerable<VwItem> GetBestSellers()
        {
            try
            {
                return DbSet
                .AsNoTracking()
                .OrderByDescending(x => x.SoldCount)    
                .ThenBy(x => Guid.NewGuid())            
                .Take(5)
                .ToList();
            }
            catch (Exception ex)
            {
                HandleException(nameof(GetAll), "An error occurred while retrieving Best Sellers.", $"Error occurred while retrieving all entities of type {typeof(VwItem).Name}.", ex);
                throw; // Rethrow the exception after logging
            }
        }
        public IEnumerable<VwItem> GetFeaturedProducts()
        {
            try
            {
                return DbSet
          .AsNoTracking()
          .OrderBy(x => Guid.NewGuid())
          .ToList();
            }
            catch (Exception ex)
            {
                HandleException(nameof(GetAll), "An error occurred while retrieving Featured Products.", $"Error occurred while retrieving all entities of type {typeof(VwItem).Name}.", ex);
                throw; // Rethrow the exception after logging
            }
        }


    }
}
