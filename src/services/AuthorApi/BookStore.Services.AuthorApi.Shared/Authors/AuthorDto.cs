namespace BookStore.Services.AuthorApi.Shared.Authors;

public abstract class AuthorDto
{
    public record Index(
        int Id,
        string Name,
        DateTime DateOfBirth
    );

    public record Detail(
        int Id,
        string Name,
        DateTime DateOfBirth
    );

    public record Mutate(
        string Name,
        DateTime DateOfBirth
    )
    {
        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .MaximumLength(100);

                RuleFor(x => x.DateOfBirth)
                    .NotNull();
            }
        }
    };
}
