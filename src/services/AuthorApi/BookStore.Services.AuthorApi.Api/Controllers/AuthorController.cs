using BookStore.Services.AuthorApi.Domain.Authors;
using BookStore.Services.AuthorApi.Shared.Authors;
using BookStore.Services.AuthorApi.Infrastructure.Mappers.Authors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.AuthorApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(
        IAuthorService authorService
    )
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<ActionResult<AuthorResponse.Create>> CreateAsync(
        [FromBody] AuthorRequest.Mutate request,
        CancellationToken cancellationToken = default!
    )
    {
        Author model = request
            .Model
            .ToAuthor();

        int id = await _authorService
            .CreateAsync(
                model,
                cancellationToken
            );

        return Ok(
            new AuthorResponse.Create(
                id
            )
        );
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorResponse.Index>>> GetAllAsync(
        [FromQuery] AuthorRequest.Index request,
        CancellationToken cancellationToken = default!
    )
    {
        IEnumerable<Author> authors = await _authorService
            .GetAllAsync(
                cancellationToken
            );

        IReadOnlyCollection<AuthorDto.Index> dtos = authors
            .Select(x =>
                x.ToIndexDto()
            )
            .ToList();

        return Ok(
            new AuthorResponse.Index(
                dtos
            )
        );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponse.Detail>> GetByIdAsync(
        int id,
        [FromQuery] AuthorRequest.Detail request,
        CancellationToken cancellationToken = default!
    )
    {
        Author author = await _authorService
            .GetByIdAsync(
                id,
                cancellationToken
            );

        AuthorDto.Detail dto = author
            .ToDetailDto();

        return Ok(
            new AuthorResponse.Detail(
                dto
            )
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateByIdAsync(
        int id,
        [FromBody] AuthorRequest.Mutate request,
        CancellationToken cancellationToken = default!
    )
    {
        Author model = request
            .Model
            .ToAuthor();

        await _authorService
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
        CancellationToken cancellation = default!
    )
    {
        await _authorService
            .DeleteByIdAsync( 
                id, 
                cancellation 
            );

        return Ok();
    }
}
