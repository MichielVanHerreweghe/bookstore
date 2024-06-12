using BookStore.Services.BookApi.Persistence;
using Microsoft.EntityFrameworkCore;
using BookStore.Services.Shared.Extensions;

namespace BookStore.Services.BookApi.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddApplicationMiddleware(
        this WebApplication app
    )
    {
        if (app.Environment.IsDevelopment())
            app
                .AddDevelopmentMiddleWare();

        app
            .UseHttpsRedirection();

        app
            .AddAuthMiddleWare();

        app

            .MapControllers();

        app
            .UseCloudEvents();

        app
            .MapSubscribeHandler();

        app
            .AddCustomMiddleware();

        using (var scope = app.Services.CreateScope())
        {
            BookDbContext dbContext = scope
                .ServiceProvider
                .GetRequiredService<BookDbContext>();

            if (app.Environment.IsDevelopment())
            {
                dbContext
                    .Database
                    .EnsureDeleted();

                dbContext
                    .Database
                    .Migrate();

                Seeder seeder = new(
                    dbContext
                );

                seeder
                    .Seed();
            }
        }

        return app;
    }
}
