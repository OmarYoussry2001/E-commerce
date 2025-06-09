
using Domains.Entities;
using Domains.Identity;
using Domains.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DAL.ApplicationContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TbDescription> TbDescription { get; set; }
        public DbSet<TbImage> TbImage { get; set; }
        public DbSet<TbItem> TbItem { get; set; }
        public DbSet<TbSalesInvoice> TbSalesInvoice { get; set; }
        public DbSet<TbSalesInvoiceItem> TbSalesInvoiceItem { get; set; }
        public DbSet<TbSettings> TbSettings { get; set; }
        public DbSet<TbSlider> TbSlider { get; set; }
        public DbSet<TbType> TbType { get; set; }

        public DbSet<VwItem> VwItem { get; set; }
        public DbSet<VwItemWithTypeName> VwItemWithTypeName { get; set; }


        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VwItem>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwItem");
            });
            modelBuilder.Entity<VwItemWithTypeName>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwItemWithTypeName");
            });

        }
    }

}
