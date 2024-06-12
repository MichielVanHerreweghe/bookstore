using BookStore.Services.AuthorApi.Persistence;
using Microsoft.EntityFrameworkCore;
using BookStore.Services.Shared.Extensions;

namespace BookStore.Services.AuthorApi.Api.Extensions;

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
            
            .MapControllers();

        app
            .AddCustomMiddleware();

        app
            .AddAuthMiddleWare();

        using (var scope = app.Services.CreateScope())
        {
            AuthorDbContext dbContext = scope
                .ServiceProvider
                .GetRequiredService<AuthorDbContext>();

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
