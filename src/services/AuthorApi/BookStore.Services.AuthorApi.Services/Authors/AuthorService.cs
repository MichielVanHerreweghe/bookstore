using BookStore.Services.AuthorApi.Domain.Authors;
using BookStore.Services.AuthorApi.Persistence;
using BookStore.Services.AuthorApi.Shared.Authors;
using BookStore.Services.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.AuthorApi.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly AuthorDbContext _dbContext;

    public AuthorService(
        AuthorDbContext dbContext    
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
                x.Id == id,
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
                model.Name,
                model.DateOfBirth
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
