using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.PizzeriaService
{
    public class PizzeriaService : IPizzeriaService
    {
        public readonly CWDbContext _cwDbContext;

        public PizzeriaService(CWDbContext cwDbContext) 
        { 
            _cwDbContext = cwDbContext;
        }

        public GenericEntityResult<Pizzeria> AddPizzeria(string pizzeriaName, string location)
        {
            _cwDbContext.Pizzerias.Add(new Pizzeria { Id = new Guid(), Name = pizzeriaName });

            var newPizzeria = _cwDbContext.Pizzerias.FirstOrDefault(_ => _.Name == pizzeriaName);

            return newPizzeria != null ? GenericEntityResult<Pizzeria>.Ok(newPizzeria) :
                GenericEntityResult<Pizzeria>.BadRequest("Pizzeria failed to add");
        }

        public GenericEntityResult<List<string>> GetPizzeriasList()
        {
            return GenericEntityResult<List<string>>.Ok(_cwDbContext.Pizzerias.Select(_ => _.Name).ToList());
        }
    }
}
