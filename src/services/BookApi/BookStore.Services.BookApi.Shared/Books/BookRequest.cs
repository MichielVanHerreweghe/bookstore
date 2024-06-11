namespace BookStore.Services.BookApi.Shared.Books;

public abstract class BookRequest
{
    public record Index(
        
    );

    public record Detail(
        
    );

    public record Mutate(
        BookDto.Mutate Model  
    );
}
