using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.PizzaService
{
    public interface IMenuService
    {
        public Task<GenericEntityResult<List<Pizza>>> GetMenuByLocation(string location);
        public Task<GenericEntityResult<List<Pizza>>> UpdateMenu(Guid pizzeriaId, List<Pizza> pizzas);
    }
}
