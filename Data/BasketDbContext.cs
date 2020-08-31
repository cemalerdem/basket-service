using System;
using System.Reflection;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) :base(options)
        {
        }

        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<BasketView> BasketViews { get; set; }
        public DbSet<ItemDetailView> ItemDetailView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDetailView>()
                .HasData(
                    new ItemDetailView{Id = Guid.NewGuid(), Name = "Iphone", UnitPrice = 1200, Quantity = 5, IsActive = true},
                    new ItemDetailView{Id = Guid.NewGuid(), Name = "Pencil", UnitPrice = 1200, Quantity = 5, IsActive = true},
                    new ItemDetailView{Id = Guid.NewGuid(), Name = "Novel", UnitPrice = 1200, Quantity = 5, IsActive = true},
                    new ItemDetailView{Id = Guid.NewGuid(), Name = "Mouse", UnitPrice = 1200, Quantity = 5, IsActive = true},
                    new ItemDetailView{Id = Guid.NewGuid(), Name = "Keyboard", UnitPrice = 1200, Quantity = 5, IsActive = true}
                );
            modelBuilder.Entity<ItemDetailView>()
                .Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,4)");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
              
            base.OnModelCreating(modelBuilder);
        }
    }
}