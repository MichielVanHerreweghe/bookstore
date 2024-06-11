namespace BookStore.Services.BookApi.Shared.Books;

public abstract class BookResponse
{
    public record Index(
        IReadOnlyCollection<BookDto.Index> Books  
    );

    public record Detail(
        BookDto.Detail Book  
    );

    public record Create(
        int Id  
    );
}
