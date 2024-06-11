using BookStore.Services.BookApi.Domain.Books;
using BookStore.Services.BookApi.Shared.Books;
using BookStore.Services.BookApi.Infrastructure.Mappers.Books;

using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.BookApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(
        IBookService bookService    
    )
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<ActionResult<BookResponse.Create>> CreateAsync(
        [FromBody] BookRequest.Mutate request,
        CancellationToken cancellationToken = default!
    )
    {
        Book model = request
            .Model
            .ToBook();

        int id = await _bookService
            .CreateAsync(
                model,
                cancellationToken
            );

        return Ok(
            new BookResponse.Create(
                id
            )
        );
    }

    [HttpGet]
    public async Task<ActionResult<BookResponse.Index>> GetAllAsync(
        [FromQuery] BookRequest.Index request,
        CancellationToken cancellationToken = default!
    )
    {
        IEnumerable<Book> books = await _bookService
            .GetAllAsync(
                cancellationToken
            );

        IReadOnlyCollection<BookDto.Index> dtos = books
            .Select(x =>
                x.ToIndexDto()
            )
            .ToList();

        return Ok(
            new BookResponse.Index(
                dtos
            )
        );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponse.Detail>> GetByIdAsync(
        int id,
        [FromQuery] BookRequest.Detail request,
        CancellationToken cancellationToken = default!
    )
    {
        Book book = await _bookService
            .GetByIdAsync(
                id,
                cancellationToken
            );

        BookDto.Detail dto = book
            .ToDetailDto();

        return Ok(
            new BookResponse.Detail(
                dto
            )
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateByIdAsync(
        int id,
        [FromBody] BookRequest.Mutate request,
        CancellationToken cancellationToken = default!
    )
    {
        Book model = request
            .Model
            .ToBook();

        await _bookService
            .UpdateByIdAsync(
                id,
                model,
                cancellationToken
            );

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken = default!
    )
    {
        await _bookService
            .DeleteByIdAsync(
                id,
                cancellationToken
            );

        return Ok();
    }
}
