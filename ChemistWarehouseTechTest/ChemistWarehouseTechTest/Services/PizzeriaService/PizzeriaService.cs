using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehouseTechTest.Services.PizzeriaService
{
    public class PizzeriaService : IPizzeriaService
    {
        public readonly CWDbContext _cwDbContext;

        public PizzeriaService(CWDbContext cwDbContext) 
        { 
            _cwDbContext = cwDbContext;
        }

        public async Task<GenericEntityResult<Pizzeria>> AddPizzeria(string pizzeriaName, string location)
        {
            await _cwDbContext.Pizzerias.AddAsync(new Pizzeria { Name = pizzeriaName, Location = location });

            await _cwDbContext.SaveChangesAsync();

            var test = _cwDbContext.Pizzerias.ToList();
            var newPizzeria = await _cwDbContext.Pizzerias.FirstOrDefaultAsync(_ => _.Name == pizzeriaName);

            return newPizzeria != null ? GenericEntityResult<Pizzeria>.Ok(newPizzeria) :
                GenericEntityResult<Pizzeria>.BadRequest("Pizzeria failed to add");
        }

        public async Task<GenericEntityResult<List<Pizzeria>>> GetPizzeriasList()
        {
            return GenericEntityResult<List<Pizzeria>>.Ok(await _cwDbContext.Pizzerias.ToListAsync());
        }

        public async Task<GenericEntityResult<Pizzeria>> GetPizzeria(Guid Id)
        {
            var pizzeria = await _cwDbContext.Pizzerias.FirstOrDefaultAsync(p => p.Id == Id);

            if(pizzeria == null)
                return GenericEntityResult<Pizzeria>.BadRequest("Pizzeria does not exist");


            return GenericEntityResult<Pizzeria>.Ok(pizzeria);
        }
    }
}
