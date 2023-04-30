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
        [Route("GetMenu")]
        public async Task<IActionResult> GetMenu(Guid Id)
        {
            var result = await _menuService.GetMenuFromPizzeria(Id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        [HttpPut]
        [Route("UpdateMenu")]
        public async Task<IActionResult> UpdateMenu(Guid pizzeriaId, List<Pizza> pizzas)
        {
            var result = await _menuService.UpdateMenu(pizzeriaId, pizzas);

            return Ok(result);
        }
    }
}
