using ChemistWarehouseTechTest.Migrations;
using ChemistWarehouseTechTest.Models;

namespace ChemistWarehouseTechTest.Services.OrderingService
{
    public class OrderingService : IOrderingService
    {
        private CWDbContext _context;

        public OrderingService(CWDbContext context)
        {
            _context = context;
        }

        public void OrderPizzas(Order order)
        {
            _context.Orders.Add(order);
        }

        public List<Order> GetOrders(Guid pizzeriaId)
        {
            return _context.Orders.Where(_ => _.PizzeriaId == pizzeriaId).ToList();
        }
    }
}
