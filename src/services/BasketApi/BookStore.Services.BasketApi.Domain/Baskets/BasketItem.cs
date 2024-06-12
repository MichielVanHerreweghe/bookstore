namespace BookStore.Services.BasketApi.Domain.Baskets;

public class BasketItem
{
    public int BookId { get; private set; }
    public string Title { get; private set; } = default!;
    public int Quantity { get; private set; }

    public BasketItem(
        int bookId,
        string title,
        int quantity
    )
    {
        BookId = Guard
            .Against
            .NegativeOrZero(
                bookId,
                nameof(bookId)
            );

        Title = Guard
            .Against
            .NullOrWhiteSpace(
                title,
                nameof(title)
            );

        Quantity = Guard
            .Against
            .NegativeOrZero(
                quantity,
                nameof(quantity)
            );
    }

    public void UpdateQuantity(
        int quantity    
    )
    {
        Quantity = Guard
            .Against
            .NegativeOrZero(
                quantity,
                nameof(quantity)
            );
    }
}
