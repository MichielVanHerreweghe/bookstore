using BookStore.Services.BookApi.Domain.Books;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Services.BookApi.Persistence.Configurations.Books;

internal class BookConfiguration : EntityConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base
            .Configure(
                builder
            );

        builder
            .HasOne(x =>
                x.Author
            )
            .WithMany();
    }
}
