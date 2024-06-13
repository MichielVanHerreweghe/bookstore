using BookStore.Services.BookApi.Domain.Authors;

namespace BookStore.Services.BookApi.Domain.Books;

public class Book : Entity
{
    public string Title { get; private set; } = default!;
    public string Synopsis { get; private set; } = default!;
    public DateTime DateOfFirstPublish { get; private set; }
    public string CoverUrl { get; private set; } = default!;

    public int AuthorId { get; private set; }
    public Author Author { get; private set; } = default!;

    private Book() { }

    public Book(
        string title,
        string synopsis,
        DateTime dateOfFirstPublish,
        string coverUrl,
        int authorId
    )
    {
        Title = Guard
            .Against
            .NullOrWhiteSpace(
                title,
                nameof(title)
            );

        Synopsis = Guard
            .Against
            .NullOrWhiteSpace(
                synopsis,
                nameof(synopsis)
            );

        DateOfFirstPublish = Guard
            .Against
            .Null(
                dateOfFirstPublish,
                nameof(dateOfFirstPublish)
            );

        CoverUrl = Guard
            .Against
            .NullOrWhiteSpace(
                coverUrl,
                nameof(coverUrl)
            );

        AuthorId = Guard
            .Against
            .NegativeOrZero(
                authorId,
                nameof(authorId)
            );
    }

    public void Update(
        string title,
        string synopsis,
        DateTime dateOfFirstPublish,
        string coverUrl,
        int authorId
    )
    {
        UpdateTitle(
            title
        );

        UpdateSynopsis(
            synopsis
        );

        UpdateDateOfFirstPublish(
            dateOfFirstPublish
        );

        UpdateCoverUrl(
            coverUrl
        );

        UpdateAuthorId(
            authorId
        );
    }

    private void UpdateTitle(
        string title    
    )
    {
        Title = Guard
            .Against
            .NullOrWhiteSpace(
                title,
                nameof(title)
            );
    }

    private void UpdateSynopsis(
        string synopsis
    )
    {
        Synopsis = Guard
            .Against
            .NullOrWhiteSpace(
                synopsis,
                nameof(synopsis)
            );
    }

    private void UpdateDateOfFirstPublish(
        DateTime dateOfFirstPublish    
    )
    {
        DateOfFirstPublish = Guard
            .Against
            .Null(
                dateOfFirstPublish,
                nameof(dateOfFirstPublish)
            );
    }

    private void UpdateCoverUrl(
        string coverUrl    
    )
    {
        CoverUrl = Guard
            .Against
            .NullOrWhiteSpace(
                coverUrl,
                nameof(coverUrl)
            );
    }

    private void UpdateAuthorId(
        int authorId    
    )
    {
        AuthorId = Guard
            .Against
            .NegativeOrZero(
                authorId,
                nameof(authorId)
            );
    }
}
