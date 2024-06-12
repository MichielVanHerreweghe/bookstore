using BookStore.Services.BookApi.Shared.Authors;

namespace BookStore.Services.BookApi.Shared.Books;

public abstract class BookDto
{
    public record Index(
        int Id,
        string Title,
        AuthorDto.Detail Author
    );

    public record Detail(
        int Id,
        string Title,
        string Synopsis,
        DateTime DateOfFirstPublish,
        string CoverUrl,
        AuthorDto.Detail Author
    );

    public record Mutate(
        string Title,
        string Synopsis,
        DateTime DateOfFirstPublish,
        string CoverUrl,
        int AuthorId
    )
    {
        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.Title)
                    .NotEmpty()
                    .MaximumLength(100);

                RuleFor(x => x.Synopsis)
                    .NotEmpty()
                    .MaximumLength(4_000);

                RuleFor(x => x.DateOfFirstPublish)
                    .NotNull();

                RuleFor(x => x.CoverUrl)
                    .NotEmpty();

                RuleFor(x => x.AuthorId)
                    .NotNull()
                    .GreaterThan(0);
            }
        }
    };
}
