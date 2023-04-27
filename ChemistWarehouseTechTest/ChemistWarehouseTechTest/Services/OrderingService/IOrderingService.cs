using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;

namespace ChemistWarehouseTechTest.Services.OrderingService
{
    public interface IOrderingService
    {
        public Task<GenericEntityResult<Order>> OrderPizzas(Order order);

        public Task<GenericEntityResult<List<Order>>> GetOrders(Guid pizzeriaId);
    }
}
