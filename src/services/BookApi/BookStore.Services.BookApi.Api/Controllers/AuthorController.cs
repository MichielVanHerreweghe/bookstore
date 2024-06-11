using BookStore.Services.BookApi.Domain.Authors;
using BookStore.Services.BookApi.Infrastructure.Events.Authors;
using BookStore.Services.BookApi.Infrastructure.Mappers.Authors;
using BookStore.Services.BookApi.Shared.Authors;
using BookStore.Services.Shared.Options;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.BookApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(
        IAuthorService authorService,
        ILogger<AuthorController> logger
    )
    {
        _authorService = authorService;
        _logger = logger;
    }

    [Topic(DaprPubSubOptions.MessageBusName, nameof(Author), $"event.type == \"{AuthorEvent.Created.RaisedEvent}\"", 1)]
    [HttpPost]
    public async Task<ActionResult> CreateAsync(
        AuthorEvent.Created raisedEvent,
        [FromServices] DaprClient dapr,
        CancellationToken cancellationToken = default!
    )
    {
        Author model = raisedEvent
            .Model
            .ToAuthor();

        await _authorService
            .CreateAsync(
                model,
                cancellationToken
            );

        return Ok();
    }

    [Topic(DaprPubSubOptions.MessageBusName, nameof(Author), $"event.type == \"{AuthorEvent.Updated.RaisedEvent}\"", 2)]
    [HttpPut]
    public async Task<ActionResult> UpdateByIdAsync(
        AuthorEvent.Updated raisedEvent,
        [FromServices] DaprClient dapr,
        CancellationToken cancellationToken = default!
    )
    {
        await _authorService
            .UpdateByIdAsync(
                raisedEvent.AuthorId,
                raisedEvent.Model.ToAuthor(),
                cancellationToken
            );

        return Ok();
    }

    [Topic(DaprPubSubOptions.MessageBusName, nameof(Author), $"event.type == \"{AuthorEvent.Deleted.RaisedEvent}\"", 3)]
    [HttpDelete]
    public async Task<ActionResult> DeleteByIdAsync(
        AuthorEvent.Deleted raisedEvent,
        [FromServices] DaprClient dapr,
        CancellationToken cancellationToken = default!
    )
    {
        await _authorService
            .DeleteByIdAsync(
                raisedEvent.AuthorId,
                cancellationToken
            );

        return Ok();
    }
}
