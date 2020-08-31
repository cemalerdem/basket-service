using Data.Entity;
using Data.Interfaces;

namespace Data.Service
{
    public class ProductRepository : Repository<ItemDetailView>, IProductRepository
    {
        public ProductRepository(BasketDbContext context) : base(context)
        {
            
        }
    }
}