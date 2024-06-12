using BookStore.Services.BookApi.Persistence;
using BookStore.Services.BookApi.Services;
using BookStore.Services.BookApi.Shared.Books;
using BookStore.Services.Shared.Extensions;

namespace BookStore.Services.BookApi.Api.Extensions;

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
            .AddDaprClient();

        services
            .AddRestServices();

        services
            .AddFluentValidationServices<BookDto.Mutate, BookDto.Mutate.Validator>();

        services
            .AddDbServices<BookDbContext>(
                configuration
            );

        return services;
    }
}
