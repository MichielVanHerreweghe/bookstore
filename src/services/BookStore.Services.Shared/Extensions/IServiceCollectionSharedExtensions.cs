using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.Shared.Extensions;

public static class IServiceCollectionSharedExtensions
{
    public static IServiceCollection AddSwaggerServices(
        this IServiceCollection services    
    )
    {
        services
            .AddEndpointsApiExplorer();

        services
            .AddSwaggerGen(options =>
                {
                    options.CustomSchemaIds(type =>
                        type.DeclaringType is null
                        ? $"{type.Name}"
                        : $"{type.DeclaringType?.Name}.{type.Name}");
                }
            )
            .AddFluentValidationRulesToSwagger();

        return services;
    }

    public static IServiceCollection AddFluentValidationServices<T, U>(
        this IServiceCollection services    
    ) where U : AbstractValidator<T>
    {
        services
            .AddValidatorsFromAssemblyContaining<U>();

        services
            .AddFluentValidationAutoValidation();

        return services;
    }

    public static IServiceCollection AddDbServices<T>(
        this IServiceCollection services,
        IConfiguration configuration
    ) where T : DbContext
    {
        services
            .AddDbContext<T>(options =>
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
