using BookStore.Services.BasketApi.Api.Extensions;

WebApplicationBuilder builder = WebApplication
    .CreateBuilder(
        args
    );

builder
    .Services
    .AddApplicationServices(
        builder
            .Configuration
    );

WebApplication app = builder
    .Build();

app
    .AddApplicationMiddleware();

app
    .Run();

