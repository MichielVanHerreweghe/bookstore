using BookStore.Services.BookApi.Domain.Authors;
using BookStore.Services.BookApi.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Services.BookApi.Persistence;

public class BookDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();

    public BookDbContext(
        DbContextOptions<BookDbContext> options    
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
