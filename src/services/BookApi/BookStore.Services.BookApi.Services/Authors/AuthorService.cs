using BookStore.Services.BookApi.Domain.Authors;
using BookStore.Services.BookApi.Persistence;
using BookStore.Services.BookApi.Shared.Authors;
using BookStore.Services.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.BookApi.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly BookDbContext _dbContext;

    public AuthorService(
        BookDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(
        Author model,
        CancellationToken cancellationToken
    )
    {
        _dbContext
            .Authors
            .Add(
                model
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );

        return model
            .Id;
    }

    public async Task<IEnumerable<Author>> GetAllAsync(
        CancellationToken cancellationToken
    )
    {
        IQueryable<Author> query = _dbContext
            .Authors
            .AsQueryable();

        return await query
            .ToListAsync(
                cancellationToken
            );
    }

    public async Task<Author> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Author? author = await _dbContext
            .Authors
            .FirstOrDefaultAsync(x =>
                x.AuthorId == id,
                cancellationToken
            );

        if (author is null)
            throw new EntityNotFoundException(
                nameof(Author),
                id
            );

        return author;
    }

    public async Task UpdateByIdAsync(
        int id,
        Author model,
        CancellationToken cancellationToken
    )
    {
        Author author = await GetByIdAsync(
            id,
            cancellationToken
        );

        author
            .Update(
                model.Name
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }

    public async Task DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Author author = await GetByIdAsync(
            id,
            cancellationToken
        );

        _dbContext
            .Authors
            .Remove(
                author
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }
}