using BookStore.Services.BookApi.Domain.Authors;

namespace BookStore.Services.BookApi.Shared.Authors;

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
