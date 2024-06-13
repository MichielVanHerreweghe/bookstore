using BookStore.Services.BookApi.Domain.Books;
using BookStore.Services.BookApi.Infrastructure.Mappers.Authors;
using BookStore.Services.BookApi.Shared.Books;

namespace BookStore.Services.BookApi.Infrastructure.Mappers.Books;

public static class BookMapper
{
    public static Book ToBook(
        this BookDto.Mutate model    
    )
    {
        Book book = new(
            model.Title,
            model.Synopsis,
            model.DateOfFirstPublish,
            model.CoverUrl,
            model.AuthorId
        );

        return book;
    }

    public static BookDto.Index ToIndexDto(
        this Book book
    )
    {
        BookDto.Index model = new(
            book.Id,
            book.Title,
            book.Author.ToDetailDto()
        );

        return model;
    }

    public static BookDto.Detail ToDetailDto(
        this Book book    
    )
    {
        BookDto.Detail model = new(
            book.Id,
            book.Title,
            book.Synopsis,
            book.DateOfFirstPublish,
            book.CoverUrl,
            book.Author.ToDetailDto()
        );

        return model;
    }
}
