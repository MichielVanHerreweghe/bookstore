using BookStore.Services.BookApi.Domain.Books;

namespace BookStore.Services.BookApi.Domain.Authors;

public class Author : Entity
{
    public string Name { get; private set; } = default!;

    private Author() { }

    public Author(
        string name
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name,
                nameof(name)
        );
    }

    public void Update(
        string name
    )
    {
        UpdateName(
            name
        );
    }

    private void UpdateName(
        string name
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name,
                nameof(name)
            );
    }
}
