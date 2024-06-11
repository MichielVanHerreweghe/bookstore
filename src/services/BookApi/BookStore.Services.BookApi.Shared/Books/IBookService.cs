using BookStore.Services.BookApi.Domain.Books;

namespace BookStore.Services.BookApi.Shared.Books;

public interface IBookService
{
    public Task<int> CreateAsync(
        Book model,
        CancellationToken cancellationToken
    );

    public Task<IEnumerable<Book>> GetAllAsync(
        CancellationToken cancellationToken
    );

    public Task<Book> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    );

    public Task UpdateByIdAsync(
        int id,
        Book model,
        CancellationToken cancellationToken
    );

    public Task DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken
    );
}