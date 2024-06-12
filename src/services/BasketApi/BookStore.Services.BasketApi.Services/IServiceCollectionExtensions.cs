using BookStore.Services.BasketApi.Services.Baskets;
using BookStore.Services.BasketApi.Shared.Baskets;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.BasketApi.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(
        this IServiceCollection services    
    )
    {
        services
            .AddScoped<IBasketService, BasketService>();

        return services;
    }
}
