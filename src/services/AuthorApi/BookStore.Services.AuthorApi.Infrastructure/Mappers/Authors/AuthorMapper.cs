using BookStore.Services.AuthorApi.Domain.Authors;
using BookStore.Services.AuthorApi.Shared.Authors;

namespace BookStore.Services.AuthorApi.Infrastructure.Mappers.Authors;

public static class AuthorMapper
{
    public static Author ToAuthor(this AuthorDto.Mutate model)
    {
        Author author = new(
            model.Name,
            model.DateOfBirth
        );

        return author;
    }

    public static AuthorDto.Index ToIndexDto(this Author author)
    {
        AuthorDto.Index model = new(
            author.Id,
            author.Name,
            author.DateOfBirth
        );

        return model;
    }

    public static AuthorDto.Detail ToDetailDto (this Author author)
    {
        AuthorDto.Detail model = new(
            author.Id,
            author.Name,
            author.DateOfBirth
        );

        return model;
    }
}
