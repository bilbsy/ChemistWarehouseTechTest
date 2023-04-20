using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.PizzeriaService
{
    public interface IPizzeriaService
    {
        GenericEntityResult<Pizzeria> AddPizzeria(string pizzeriaName, string location);
        public GenericEntityResult<List<string>> GetPizzeriasList();
    }
}
