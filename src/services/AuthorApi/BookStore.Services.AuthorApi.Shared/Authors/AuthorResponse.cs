namespace BookStore.Services.AuthorApi.Shared.Authors;

public abstract class AuthorResponse
{
    public record Index(
        IReadOnlyCollection<AuthorDto.Index> Authors    
    );

    public record Detail(
        AuthorDto.Detail Author  
    );

    public record Create(
        int Id    
    );
}
