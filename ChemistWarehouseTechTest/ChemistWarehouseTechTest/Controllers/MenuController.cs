using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Services.PizzaService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
using Microsoft.AspNetCore.Mvc;

namespace ChemistWarehouseTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService) {
            _menuService = menuService;
        }


        [HttpGet]
        [Route("/GetMenu")]
        public IActionResult GetMenu(string location)
        {
            var result = _menuService.GetMenuByLocation(location);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        [HttpPut]
        [Route("/UpdateMenu")]
        public IActionResult UpdateMenu(string pizzeriaName, List<Pizza> pizzas)
        {
            var result = _menuService.UpdateMenu(pizzeriaName, pizzas);

            return Ok(result);
        }
    }
}
