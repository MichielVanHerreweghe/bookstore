using BookStore.Services.AuthorApi.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Services.AuthorApi.Persistence;

public class AuthorDbContext : DbContext
{
    public DbSet<Author> Author => Set<Author>();

    public AuthorDbContext(
        DbContextOptions<AuthorDbContext> options
    ) : base(options) { }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        base
            .OnConfiguring(
                optionsBuilder
            );

        optionsBuilder
            .EnableDetailedErrors();

        optionsBuilder
            .EnableSensitiveDataLogging();
    }

    protected override void ConfigureConventions(
        ModelConfigurationBuilder configurationBuilder
    )
    {
        configurationBuilder
            .Properties<decimal>()
            .HavePrecision(
                18, 
                2
            );

        configurationBuilder.Properties<string>()
            .HaveMaxLength(
                4_000
            );
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {
        base
            .OnModelCreating(
                modelBuilder
            );

        modelBuilder
            .ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
    }
}
