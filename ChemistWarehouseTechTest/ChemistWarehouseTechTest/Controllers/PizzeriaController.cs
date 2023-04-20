using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Services.PizzaService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
using Microsoft.AspNetCore.Mvc;

namespace ChemistWarehouseTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzeriaController : ControllerBase
    {
        private readonly IPizzeriaService _pizzeriaService;

        public PizzeriaController(IPizzeriaService pizzeriaService) 
        {
            _pizzeriaService = pizzeriaService;
        }

        [HttpGet]
        public IActionResult GetPizzerias()
        {
            var result = _pizzeriaService.GetPizzeriasList().Data;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddPizzeria(string pizzeriaName, string location)
        {
            var result = _pizzeriaService.AddPizzeria(pizzeriaName, location);

            return Ok(result.Data);
        }
    }
}
