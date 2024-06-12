using BookStore.Services.Shared.Extensions;
using BookStore.Services.BasketApi.Services;
using BookStore.Services.Shared.Options;

namespace BookStore.Services.BasketApi.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddControllers();

        services
            .AddSwaggerServices();

        services
            .AddApplicationOptions(
                configuration
            );

        services
            .AddRestServices();

        services
            .AddDaprClient();

        return services;
    }

    public static IServiceCollection AddApplicationOptions(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddOptions();

        services
            .Configure<DaprStateStoreOptions>(
                configuration
                    .GetSection(
                        DaprStateStoreOptions.DaprStateStore
                    )
            );

        return services;
    }
}
