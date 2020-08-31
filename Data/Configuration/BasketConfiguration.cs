using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class BasketConfiguration : IEntityTypeConfiguration<BasketView>
    {
        public void Configure(EntityTypeBuilder<BasketView> builder)
        {
        }
    }
}