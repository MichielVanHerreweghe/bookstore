namespace BookStore.Services.BasketApi.Shared.Baskets;

public abstract class BasketDto
{
    public record Index(
        IReadOnlyCollection<BasketItemDto.Index> BasketItems
    );

    public record Mutate(
        IReadOnlyCollection<BasketItemDto.Index> BasketItems
    );
}
