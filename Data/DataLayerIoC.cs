using Data.Interfaces;
using Data.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataLayerIoC
    {
        public static IServiceCollection AddDataLayerDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IBasketItemRepository, BasketItemRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            
            return services;
        }
    }
}