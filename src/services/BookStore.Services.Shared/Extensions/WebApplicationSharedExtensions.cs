using BookStore.Services.Shared.Middleware;
using Microsoft.AspNetCore.Builder;

namespace BookStore.Services.Shared.Extensions;

public static class WebApplicationSharedExtensions
{
    public static WebApplication AddDevelopmentMiddleWare(
        this WebApplication app
    )
    {
        app
            .UseSwagger();

        app
            .UseSwaggerUI();

        return app;
    }

    public static WebApplication AddCustomMiddleware(
        this WebApplication app
    )
    {
        app
            .UseMiddleware<ExceptionMiddleware>();

        return app;
    }

    public static WebApplication AddAuthMiddleWare(
        this WebApplication app
    )
    {
        app
            .UseAuthorization();

        return app;
    }
}
