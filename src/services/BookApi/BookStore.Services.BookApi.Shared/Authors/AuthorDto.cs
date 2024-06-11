namespace BookStore.Services.BookApi.Shared.Authors;

public abstract class AuthorDto
{
    public record Index(
        int Id,
        int AuthorId,
        string Name
    );

    public record Detail(
        int Id,
        int AuthorId,
        string Name
    );

    public record Mutate(
        int AuthorId,
        string Name  
    );
}
