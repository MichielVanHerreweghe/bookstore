namespace BookStore.Services.AuthorApi.Domain.Authors;

public class Author : Entity
{
    public string Name { get; private set; } = default!;
    public DateTime DateOfBirth { get; set; }

    private Author() { }

    public Author(
        string name,
        DateTime dateOfBirth
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name, 
                nameof(name)
            );

        DateOfBirth = Guard
            .Against
            .OutOfRange(
                dateOfBirth,
                nameof(dateOfBirth),
                DateTime.MinValue,
                DateTime.UtcNow
            );
    }

    public void Update(
        string name,
        DateTime dateOfBirth
    )
    {
        UpdateName(
            name
        );

        UpdateDateOfBirth(
            dateOfBirth
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

    private void UpdateDateOfBirth(DateTime dateOfBirth)
    {
        DateOfBirth = Guard
            .Against
            .OutOfRange(
                dateOfBirth,
                nameof(dateOfBirth),
                DateTime.MinValue,
                DateTime.UtcNow
            );
    }
}
