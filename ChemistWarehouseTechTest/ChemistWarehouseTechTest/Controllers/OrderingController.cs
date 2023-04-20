using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Services.OrderingService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
using Microsoft.AspNetCore.Mvc;

namespace ChemistWarehouseTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderingController : ControllerBase
    {
        private readonly IOrderingService _orderingService;

        public OrderingController(IOrderingService orderingService) {
            _orderingService = orderingService;
        }

        [HttpPost]
        public IActionResult SendOrder(Order pizzaOrder)
        {
            _orderingService.OrderPizzas(pizzaOrder);

            return Ok();
        }

        [HttpGet]
        [Route("/GetOrders")]
        public IActionResult GetOrders(Guid pizzeriaId)
        {
            return Ok(_orderingService.GetOrders(pizzeriaId));
        }
    }
}
