using BookStore.Services.BookApi.Persistence;
using BookStore.Services.Shared.Middleware;
using Microsoft.EntityFrameworkCore;

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

    private static WebApplication AddDevelopmentMiddleWare(
        this WebApplication app
    )
    {
        app
            .UseSwagger();

        app
            .UseSwaggerUI();

        return app;
    }

    private static WebApplication AddCustomMiddleware(
        this WebApplication app
    )
    {
        app
            .UseMiddleware<ExceptionMiddleware>();

        return app;
    }

    private static WebApplication AddAuthMiddleWare(
        this WebApplication app
    )
    {
        app
            .UseAuthorization();

        return app;
    }
}
