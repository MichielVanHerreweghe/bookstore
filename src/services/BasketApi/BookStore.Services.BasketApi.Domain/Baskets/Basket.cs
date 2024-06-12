namespace BookStore.Services.BasketApi.Domain.Baskets;

public class Basket
{
    public List<BasketItem> BasketItems { get; set; }

    public Basket() : this(new List<BasketItem>()) { }

    public Basket(List<BasketItem> basketItems)
    {
        BasketItems = basketItems;
    }

    public void Update(
        List<BasketItem> basketItems
    )
    {
        UpdateBasketItems(
            basketItems
        );
    }

    private void UpdateBasketItems(
        List<BasketItem> basketItems    
    )
    {
        BasketItems
            .AddRange(
                basketItems
            );
    }
}
