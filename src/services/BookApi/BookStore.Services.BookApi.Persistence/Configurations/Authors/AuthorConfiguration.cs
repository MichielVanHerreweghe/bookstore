using BookStore.Services.BookApi.Domain.Authors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Services.BookApi.Persistence.Configurations.Authors;

internal class AuthorConfiguration : EntityConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base
            .Configure(
                builder
            );
    }
}
