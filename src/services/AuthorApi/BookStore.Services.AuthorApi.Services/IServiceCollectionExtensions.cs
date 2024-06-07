using BookStore.Services.AuthorApi.Services.Authors;
using BookStore.Services.AuthorApi.Shared.Authors;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.AuthorApi.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(
        this IServiceCollection services    
    )
    {
        services
            .AddScoped<IAuthorService, AuthorService>();

        return services;
    }
}
