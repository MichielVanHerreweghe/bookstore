namespace BookStore.Services.BasketApi.Shared.Baskets;

public class BasketItemDto
{
    public record Index(
        int BookId,
        string Title,
        int Quantity
    );
}
