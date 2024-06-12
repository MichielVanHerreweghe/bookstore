using BookStore.Services.Shared.Extensions;

namespace BookStore.Services.BasketApi.Api.Extensions;

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

        return app;
    }
}
