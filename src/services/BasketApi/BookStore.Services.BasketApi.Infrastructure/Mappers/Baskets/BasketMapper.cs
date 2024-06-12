using BookStore.Services.BasketApi.Domain.Baskets;
using BookStore.Services.BasketApi.Shared.Baskets;

namespace BookStore.Services.BasketApi.Infrastructure.Mappers.Baskets;

public static class BasketMapper
{
    public static Basket ToBasket(
        this BasketDto.Mutate model    
    )
    {
        Basket basket = new(
            model.BasketItems
                .Select(x =>
                    x.ToBasketItem()
                )
                .ToList()
        );

        return basket;
    }

    public static BasketDto.Index ToIndexDto(
        this Basket basket
    )
    {
        BasketDto.Index dto = new(
            basket.BasketItems
                .Select(x =>
                    x.ToIndexDto()
                )
                .ToList()
        );

        return dto;
    }
}
