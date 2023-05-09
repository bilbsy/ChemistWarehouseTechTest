using Microsoft.AspNetCore.Mvc;
using ReactCsharpExperienceProof.Models;
using ReactCsharpExperienceProof.Services.OrderingService;

namespace ReactCsharpExperienceProof.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderingController : ControllerBase
{
    private readonly IOrderingService _orderingService;

    public OrderingController(IOrderingService orderingService)
    {
        _orderingService = orderingService;
    }

    [HttpPost]
    public async Task<IActionResult> SendOrder(Order pizzaOrder)
    {
        await _orderingService.OrderPizzas(pizzaOrder);

        return Ok();
    }

    [HttpGet]
    [Route("/GetOrders")]
    public async Task<IActionResult> GetOrders(Guid pizzeriaId)
    {
        return Ok(await _orderingService.GetOrders(pizzeriaId));
    }
}