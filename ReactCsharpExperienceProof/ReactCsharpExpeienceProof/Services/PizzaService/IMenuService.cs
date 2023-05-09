using ReactCsharpExperienceProof.Models;
using ReactCsharpExperienceProof.Results;

namespace ReactCsharpExperienceProof.Services.PizzaService;

public interface IMenuService
{
    public Task<GenericEntityResult<List<Pizza>>> GetMenuFromPizzeria(Guid Id);
    public Task<GenericEntityResult<List<Pizza>>> UpdateMenu(Guid pizzeriaId, List<Pizza> pizzas);
}