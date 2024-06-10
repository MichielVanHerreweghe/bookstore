using BookStore.Services.BookApi.Domain.Books;
using BookStore.Services.BookApi.Persistence;
using BookStore.Services.BookApi.Shared.Books;
using BookStore.Services.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.BookApi.Services.Books;

public class BookService : IBookService
{
    private readonly BookDbContext _dbContext;

    public BookService(
        BookDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(
        Book model,
        CancellationToken cancellationToken
    )
    {
        _dbContext
            .Books
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

    public async Task<IEnumerable<Book>> GetAllAsync(
        CancellationToken cancellationToken
    )
    {
        IQueryable<Book> query = _dbContext
            .Books
            .AsQueryable();

        return await query
            .ToListAsync(
                cancellationToken
            );
    }

    public async Task<Book> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Book? book = await _dbContext
            .Books
            .FirstOrDefaultAsync(x =>
                x.Id == id,
                cancellationToken
            );

        if (book is null)
            throw new EntityNotFoundException(
                nameof(Book),
                id
            );

        return book;
    }

    public async Task UpdateByIdAsync(
        int id,
        Book model,
        CancellationToken cancellationToken
    )
    {
        Book book = await GetByIdAsync(
            id,
            cancellationToken
        );

        book
            .Update(
                model.Title,
                model.Synopsis,
                model.DateOfFirstPublish,
                model.AuthorId
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
        Book book = await GetByIdAsync(
            id,
            cancellationToken
        );

        _dbContext
            .Books
            .Remove(
                book
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }
}
