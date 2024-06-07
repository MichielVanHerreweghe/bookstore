namespace BookStore.Services.AuthorApi.Shared.Authors;

public abstract class AuthorRequest
{
    public record Index(
          
    );

    public record Detail(
        
    );

    public record Mutate(
        AuthorDto.Mutate Model    
    );
}
