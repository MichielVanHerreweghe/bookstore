using BookStore.Services.BookApi.Shared.Authors;

namespace BookStore.Services.BookApi.Infrastructure.Events.Authors;

public abstract class AuthorEvent
{
    public record Created(
        AuthorDto.Mutate Model
    )
    {
        public const string RaisedEvent = "AuthorEvent.Created";
    };

    public record Updated(
        int AuthorId,
        AuthorDto.Mutate Model
    )
    {
        public const string RaisedEvent = "AuthorEvent.Updated";
    };

    public record Deleted(
        int AuthorId
    )
    {
        public const string RaisedEvent = "AuthorEvent.Deleted";
    };
}
