using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.PizzaService
{
    public interface IMenuService
    {
        public GenericEntityResult<List<Pizza>> GetMenuByLocation(string location);
        public GenericEntityResult<List<Pizza>> UpdateMenu(string pizzeriaName, List<Pizza> pizzas);
    }
}
