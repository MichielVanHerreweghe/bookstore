using BookStore.Services.BasketApi.Domain.Baskets;
using BookStore.Services.BasketApi.Shared.Baskets;
using BookStore.Services.BasketApi.Infrastructure.Mappers.Baskets;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.BasketApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ILogger<BasketController> _logger;
    public BasketController(
        IBasketService basketService,
        ILogger<BasketController> logger
    )
    {
        _basketService = basketService;
        _logger = logger;
    }

    [HttpGet("{customerId}")]
    public async Task<ActionResult<BasketDto.Index>> GetByCustomerIdAsync(
        Guid customerId,
        CancellationToken cancellationToken = default!
    )
    {
        Basket basket = await _basketService
            .GetByCustomerIdAsync(
                customerId,
                cancellationToken
            );

        BasketDto.Index dto = basket
            .ToIndexDto();

        return Ok(
            dto
        );
    }

    [HttpPut("{customerId}")]
    public async Task<ActionResult> UpdateByCustomerIdAsync(
        Guid customerId,
        [FromBody] BasketDto.Mutate model,
        CancellationToken cancellationToken = default!
    )
    {
        Basket basket = model
            .ToBasket();

        await _basketService
            .UpdateByCustomerIdAsync(
                customerId,
                basket,
                cancellationToken
            );

        return Ok();
    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult> DeleteByCustomerIdAsync(
        Guid customerId,
        CancellationToken cancellationToken = default!
    )
    {
        await _basketService
            .DeleteByCustomerIdAsync(
                customerId,
                cancellationToken
            );

        return Ok();
    }
}
