using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Service;


namespace Service
{
    public static class ServiceLayerIoC
    {
        public static IServiceCollection AddServiceLayerDependencies(this IServiceCollection service)
        {
            service.AddScoped<IBasketService, BasketService>();
            return service;
        }
    }
}