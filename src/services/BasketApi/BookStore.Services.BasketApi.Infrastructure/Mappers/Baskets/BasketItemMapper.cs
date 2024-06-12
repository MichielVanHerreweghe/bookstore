using BookStore.Services.BasketApi.Domain.Baskets;
using BookStore.Services.BasketApi.Shared.Baskets;

namespace BookStore.Services.BasketApi.Infrastructure.Mappers.Baskets;

public static class BasketItemMapper
{
    public static BasketItem ToBasketItem(
        this BasketItemDto.Index model
    )
    {
        BasketItem basketItem = new(
            model.BookId,
            model.Title,
            model.Quantity
        );

        return basketItem;
    }

    public static BasketItemDto.Index ToIndexDto(
        this BasketItem basketItem    
    )
    {
        BasketItemDto.Index dto = new(
            basketItem.BookId,
            basketItem.Title,
            basketItem.Quantity
        );

        return dto;
    }
}
