using BookStore.Services.AuthorApi.Persistence;
using BookStore.Services.AuthorApi.Services;
using BookStore.Services.AuthorApi.Shared.Authors;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

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
            .AddDbServices(
                configuration
            );

        return services;
    }

    private static IServiceCollection AddSwaggerServices(
        this IServiceCollection services
    )
    {
        services
            .AddEndpointsApiExplorer();

        services
            .AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.DeclaringType is null ? $"{type.Name}" : $"{type.DeclaringType?.Name}.{type.Name}");
            })
            .AddFluentValidationRulesToSwagger();

        return services;
    }

    private static IServiceCollection AddFluentValidationServices(
        this IServiceCollection services   
    )
    {
        services
            .AddValidatorsFromAssemblyContaining<AuthorDto.Mutate.Validator>();

        services
            .AddFluentValidationAutoValidation();

        return services;
    }

    private static IServiceCollection AddDbServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddDbContext<AuthorDbContext>(options =>
                {
                    options
                        .UseSqlServer(
                            configuration
                                .GetConnectionString("database")
                        );
                }
            );

        return services;
    }
}
