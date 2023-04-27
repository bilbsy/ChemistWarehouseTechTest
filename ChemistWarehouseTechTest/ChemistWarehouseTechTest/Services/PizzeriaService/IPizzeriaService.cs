using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.PizzeriaService
{
    public interface IPizzeriaService
    {
        public Task<GenericEntityResult<Pizzeria>> AddPizzeria(string pizzeriaName, string location);
        public Task<GenericEntityResult<List<Pizzeria>>> GetPizzeriasList();
        public Task<GenericEntityResult<Pizzeria>> GetPizzeria(Guid Id);
    }
}
