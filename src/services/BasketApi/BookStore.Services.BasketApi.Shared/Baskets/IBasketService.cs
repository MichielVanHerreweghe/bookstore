using BookStore.Services.BasketApi.Domain.Baskets;

namespace BookStore.Services.BasketApi.Shared.Baskets;

public interface IBasketService
{
    Task<Basket> CreateByCustomerIdAsync(
        Guid customerId,
        CancellationToken cancellationToken
    );

    Task<Basket> GetByCustomerIdAsync(
        Guid customerId,
        CancellationToken cancellationToken
    );

    Task UpdateByCustomerIdAsync(
        Guid customerId,
        Basket model,
        CancellationToken cancellationToken
    );

    Task DeleteByCustomerIdAsync(
        Guid customerId,
        CancellationToken cancellationToken
    );
}
