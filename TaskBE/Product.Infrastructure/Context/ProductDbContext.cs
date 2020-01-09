using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;

namespace Product.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        #region Constructor

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        #endregion Constructor

        #region Properties

        public DbSet<Products> Products { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<DietaryFlags> DietaryFlags { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

            
            modelBuilder.Entity<Products>().HasKey(p => p.ID);
            modelBuilder.Entity<Products>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<Vendor>().HasKey(p => p.ID);
            modelBuilder.Entity<Vendor>().HasMany(v => v.ProductList)
                .WithOne(p => p.Vendor).HasForeignKey(p => p.VendorID);

            modelBuilder.Entity<DietaryFlags>().HasKey(p => p.ID);
            modelBuilder.Entity<DietaryFlags>().HasMany(v => v.ProductList)
                .WithOne(p => p.DietaryFlag).HasForeignKey(p => p.DietaryID);

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DietaryFlags>().HasData(
                new DietaryFlags { ID = 1, Name = "vegan" },
                new DietaryFlags { ID = 2, Name = "lactose-free" });

            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { ID = 1, Name = "Vendor1" },
                new Vendor { ID = 2, Name = "Vendor2" });

            modelBuilder.Entity<Products>().HasData(
               new Products { ID = 1, Title = "Product1", Description = "This is a description for product1", DietaryID = 1, NumberOfViews = 2, Price = 20, VendorID = 1 },
               new Products { ID = 2, Title = "Product2", Description = "This is a description for product2", DietaryID = 2, NumberOfViews = 0, Price = 40, VendorID = 2 });
        }

        #endregion Methods
    }
}