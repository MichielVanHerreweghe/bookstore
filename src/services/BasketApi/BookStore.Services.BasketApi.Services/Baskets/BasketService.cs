using BookStore.Services.BasketApi.Domain.Baskets;
using BookStore.Services.BasketApi.Shared.Baskets;
using BookStore.Services.Shared.Options;
using Dapr.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStore.Services.BasketApi.Services.Baskets;

public class BasketService : IBasketService
{
    private readonly DaprClient _dapr;
    private readonly DaprStateStoreOptions _options;
    private readonly ILogger<BasketService> _logger;

    public BasketService(
        DaprClient dapr,
        IOptions<DaprStateStoreOptions> options,
        ILogger<BasketService> logger
    )
    {
        _dapr = dapr;
        _logger = logger;
        _options = options.Value 
            ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task<Basket> CreateByCustomerIdAsync(
        Guid customerId,
        CancellationToken cancellationToken
    )
    {
        Basket basket = new();

        await _dapr
            .SaveStateAsync(
                _options.StateStoreName,
                customerId.ToString(),
                basket,
                cancellationToken: cancellationToken
            );

        return basket;
    }

    public async Task<Basket> GetByCustomerIdAsync(
        Guid customerId, 
        CancellationToken cancellationToken
    )
    {
        Basket? basket = await _dapr
            .GetStateAsync<Basket>(
                _options.StateStoreName,
                customerId.ToString(),
                cancellationToken: cancellationToken
            );

        if (basket is null)
            basket = await CreateByCustomerIdAsync(
                customerId,
                cancellationToken
            );

        return basket;
    }

    public async Task UpdateByCustomerIdAsync(
        Guid customerId, 
        Basket model, 
        CancellationToken cancellationToken
    )
    {
        Basket basket = await GetByCustomerIdAsync(
            customerId,
            cancellationToken
        );

        basket
            .Update(
                model.BasketItems.ToList()
            );

        await _dapr
            .SaveStateAsync(
                _options.StateStoreName,
                customerId.ToString(),
                basket,
                cancellationToken: cancellationToken
            );
    }

    public async Task DeleteByCustomerIdAsync(
        Guid customerId, 
        CancellationToken cancellationToken
    )
    {

        await _dapr
            .DeleteStateAsync(
                _options.StateStoreName,
                customerId.ToString(),
                cancellationToken: cancellationToken
            );
    }
}
