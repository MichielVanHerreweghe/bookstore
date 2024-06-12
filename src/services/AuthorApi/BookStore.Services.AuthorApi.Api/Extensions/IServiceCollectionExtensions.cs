using BookStore.Services.AuthorApi.Persistence;
using BookStore.Services.AuthorApi.Services;
using BookStore.Services.AuthorApi.Shared.Authors;
using BookStore.Services.Shared.Extensions;

namespace BookStore.Services.AuthorApi.Api.Extensions;

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
            .AddRestServices();

        services
            .AddDaprClient();

        services
            .AddFluentValidationServices<AuthorDto.Mutate, AuthorDto.Mutate.Validator>();

        services
            .AddDbServices<AuthorDbContext>(
                configuration
            );

        return services;
    }
}
