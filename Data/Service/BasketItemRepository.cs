using Data.Entity;
using Data.Interfaces;

namespace Data.Service
{
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(BasketDbContext context) : base(context)
        {
        }
    }
}