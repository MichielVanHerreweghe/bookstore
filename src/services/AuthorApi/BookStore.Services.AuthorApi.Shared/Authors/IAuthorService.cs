using BookStore.Services.AuthorApi.Domain.Authors;

namespace BookStore.Services.AuthorApi.Shared.Authors;

public interface IAuthorService
{
    public Task<int> CreateAsync(
        Author model,
        CancellationToken cancellationToken
    );

    public Task<IEnumerable<Author>> GetAllAsync(
        CancellationToken cancellationToken
    );

    public Task<Author> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    );

    public Task UpdateByIdAsync(
        int id,
        Author model,
        CancellationToken cancellationToken
    );

    public Task DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken
    );
}
