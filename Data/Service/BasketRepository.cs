using Data.Entity;
using Data.Interfaces;

namespace Data.Service
{
    public class BasketRepository : Repository<BasketView>, IBasketRepository
    {
        public BasketRepository(BasketDbContext context) : base(context)
        {
        }
    }
}