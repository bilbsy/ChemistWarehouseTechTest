using ReactCsharpExperienceProof.Models;
using ReactCsharpExperienceProof.Results;

namespace ReactCsharpExperienceProof.Services.PizzeriaService;

public interface IPizzeriaService
{
    public Task<GenericEntityResult<Pizzeria>> AddPizzeria(string pizzeriaName, string location);
    public Task<GenericEntityResult<List<Pizzeria>>> GetPizzeriasList();
    public Task<GenericEntityResult<Pizzeria>> GetPizzeria(Guid Id);
}