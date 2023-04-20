using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.PizzaService
{
    public class MenuService : IMenuService
    {
        public readonly CWDbContext _cwDbContext;
        public MenuService(CWDbContext cwDbContext)
        {
            _cwDbContext = cwDbContext;
        }

        public GenericEntityResult<List<Pizza>> GetMenuByLocation(string location)
        {
            if (!string.IsNullOrEmpty(location) && _cwDbContext.Pizzerias.Any(_ => _.Name == location))
                return GenericEntityResult<List<Pizza>>.Ok(_cwDbContext.Pizzerias.First(_ => _.Name == location.ToString()).Pizzas);

            return GenericEntityResult<List<Pizza>>.BadRequest("Location not found.");
        }

        public GenericEntityResult<List<Pizza>> UpdateMenu(string pizzeriaName, List<Pizza> pizzas)
        {
            _cwDbContext.Pizzerias.SingleOrDefault(_ => _.Name == pizzeriaName).Pizzas = pizzas;

            return GenericEntityResult<List<Pizza>>.Ok(_cwDbContext.Pizzerias.SingleOrDefault(_ => _.Name == pizzeriaName).Pizzas);
        }
    }
}
