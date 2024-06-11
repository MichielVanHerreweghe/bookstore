using BookStore.Services.AuthorApi.Domain.Authors;

namespace BookStore.Services.AuthorApi.Persistence;

public class Seeder
{
    private readonly AuthorDbContext _dbContext;

    public Seeder(
        AuthorDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        SeedAuthors();
    }

    private void SeedAuthors()
    {
        List<Author> authors = new()
        {
            new Author(
                "Brandon Sanderson",
                new DateTime(
                    1975, 
                    12, 
                    19
                )
            ),
            new Author(
                "Frank Herbert",
                new DateTime(
                    1920, 
                    10, 
                    8
                )
            )
        };

        _dbContext
            .Authors
            .AddRange(authors);

        _dbContext
            .SaveChanges();
    }
}
