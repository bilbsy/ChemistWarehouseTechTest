using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ChemistWarehouseTechTest.Services.PizzaService
{
    public class MenuService : IMenuService
    {
        public readonly CWDbContext _cwDbContext;
        public MenuService(CWDbContext cwDbContext)
        {
            _cwDbContext = cwDbContext;
        }

        public async Task<GenericEntityResult<List<Pizza>>> GetMenuFromPizzeria(Guid Id)
        {
            var pizzeriaMenu = await _cwDbContext.Pizzas.Where(_ => _.PizzeriaId == Id).ToListAsync();

            if(pizzeriaMenu == null)
            {
                return GenericEntityResult<List<Pizza>>.BadRequest("Location not found.");
            }

            return GenericEntityResult<List<Pizza>>.Ok(pizzeriaMenu);

        }

        public async Task<GenericEntityResult<List<Pizza>>> UpdateMenu(Guid pizzeriaId, List<Pizza> pizzas)
        {
            var menu = await _cwDbContext.Pizzas.Where(_ => _.Id == pizzeriaId).ToListAsync();

            foreach(var pizza in pizzas)
            {
                if (menu.Any())
                {

                }
            }

            if (menu == null)
                return GenericEntityResult<List<Pizza>>.BadRequest("Pizzeria provided was not found.");

            _cwDbContext.SaveChanges();

            return GenericEntityResult<List<Pizza>>.Ok(menu);
        }
    }
}
