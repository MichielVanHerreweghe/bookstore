using BookStore.Services.BookApi.Domain.Authors;
using BookStore.Services.BookApi.Shared.Authors;

namespace BookStore.Services.BookApi.Infrastructure.Mappers.Authors;

public static class AuthorMapper
{
    public static Author ToAuthor(
        this AuthorDto.Mutate model
    )
    {
        Author author = new(
            model.AuthorId,
            model.Name
        );

        return author;
    }

    public static AuthorDto.Index ToIndexDto(
        this Author author
    )
    {
        AuthorDto.Index model = new(
            author.Id,
            author.AuthorId,
            author.Name
        );

        return model;
    }

    public static AuthorDto.Detail ToDetailDto(
        this Author author
    )
    {
        AuthorDto.Detail model = new(
            author.Id,
            author.AuthorId,
            author.Name
        );

        return model;
    }
}
