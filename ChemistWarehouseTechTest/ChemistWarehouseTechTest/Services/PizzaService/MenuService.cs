using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehouseTechTest.Services.PizzaService
{
    public class MenuService : IMenuService
    {
        public readonly CWDbContext _cwDbContext;
        public MenuService(CWDbContext cwDbContext)
        {
            _cwDbContext = cwDbContext;
        }

        public async Task<GenericEntityResult<List<Pizza>>> GetMenuByLocation(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                return GenericEntityResult<List<Pizza>>.BadRequest("Location required.");
            }

            var pizzeriaMenu = (await _cwDbContext.Pizzerias.Include(_ => _.Pizzas).FirstOrDefaultAsync(_ => _.Location == location))?.Pizzas;

            if(pizzeriaMenu == null)
            {
                return GenericEntityResult<List<Pizza>>.BadRequest("Location not found.");
            }

            return GenericEntityResult<List<Pizza>>.Ok(pizzeriaMenu);

        }

        public async Task<GenericEntityResult<List<Pizza>>> UpdateMenu(Guid pizzeriaId, List<Pizza> pizzas)
        {
            var menu = await _cwDbContext.Pizzerias.FirstOrDefaultAsync(_ => _.Id == pizzeriaId);

            if (menu == null)
                return GenericEntityResult<List<Pizza>>.BadRequest("Pizzeria provided was not found.");

            menu.Pizzas = pizzas;

            _cwDbContext.SaveChanges();

            return GenericEntityResult<List<Pizza>>.Ok(menu.Pizzas);
        }
    }
}
