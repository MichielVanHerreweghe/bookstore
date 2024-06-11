using BookStore.Services.AuthorApi.Domain.Authors;
using BookStore.Services.AuthorApi.Persistence;
using BookStore.Services.AuthorApi.Shared.Authors;
using BookStore.Services.BookApi.Infrastructure.Events.Authors;
using BookStore.Services.Shared.Exceptions;
using BookStore.Services.Shared.Options;
using Dapr.Client;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.AuthorApi.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly AuthorDbContext _dbContext;
    private readonly DaprClient _dapr;

    public AuthorService(
        AuthorDbContext dbContext,
        DaprClient dapr
    )
    {
        _dbContext = dbContext;
        _dapr = dapr;
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

        await _dapr
            .PublishEventAsync(
                DaprPubSubOptions.MessageBusName,
                nameof(Author),
                new AuthorEvent.Created(
                    new(
                        model.Id,
                        model.Name
                    )                   
                ),
                new Dictionary<string, string>()
                {
                    {
                        DaprPubSubOptions.EventType,
                        AuthorEvent.Created.RaisedEvent
                    }
                },
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

        await _dapr
            .PublishEventAsync(
                DaprPubSubOptions.MessageBusName,
                nameof(Author),
                new AuthorEvent.Updated(
                    id,
                    new(
                        id,
                        model.Name
                    )
                ),
                new Dictionary<string, string>()
                {
                    {
                        DaprPubSubOptions.EventType,
                        AuthorEvent.Updated.RaisedEvent
                    }
                },
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

        await _dapr
            .PublishEventAsync(
                DaprPubSubOptions.MessageBusName,
                nameof(Author),
                new AuthorEvent.Deleted(
                    id
                ),
                new Dictionary<string, string>()
                {
                    {
                        DaprPubSubOptions.EventType,
                        AuthorEvent.Deleted.RaisedEvent
                    }
                },
                cancellationToken
            );
    }
}
