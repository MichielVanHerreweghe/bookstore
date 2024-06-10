using BookStore.Services.BookApi.Services.Authors;
using BookStore.Services.BookApi.Services.Books;
using BookStore.Services.BookApi.Shared.Authors;
using BookStore.Services.BookApi.Shared.Books;
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

        services
            .AddScoped<IBookService, BookService>();

        return services;
    }
}
