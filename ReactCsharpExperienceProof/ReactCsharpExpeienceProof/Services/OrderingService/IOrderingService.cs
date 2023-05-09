using ReactCsharpExperienceProof.Models;
using ReactCsharpExperienceProof.Results;

namespace ReactCsharpExperienceProof.Services.OrderingService;

public interface IOrderingService
{
    public Task<GenericEntityResult<Order>> OrderPizzas(Order order);

    public Task<GenericEntityResult<List<Order>>> GetOrders(Guid pizzeriaId);
}