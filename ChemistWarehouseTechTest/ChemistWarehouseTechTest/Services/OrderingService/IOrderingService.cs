using ChemistWarehouseTechTest.Models;

namespace ChemistWarehouseTechTest.Services.OrderingService
{
    public interface IOrderingService
    {
        public void OrderPizzas(Order order);

        public List<Order> GetOrders(Guid pizzeriaId);
    }
}
