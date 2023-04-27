using ChemistWarehouseTechTest.Migrations;
using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Results;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehouseTechTest.Services.OrderingService
{
    public class OrderingService : IOrderingService
    {
        private CWDbContext _context;

        public OrderingService(CWDbContext context)
        {
            _context = context;
        }

        public async Task<GenericEntityResult<Order>> OrderPizzas(Order order)
        {
            var result = await _context.Orders.AddAsync(order);

            if(result.Entity == null)
            {
                return GenericEntityResult<Order>.BadRequest("Order hasn't been added");
            }

            return GenericEntityResult<Order>.Ok(result.Entity);
        }

        public async Task<GenericEntityResult<List<Order>>> GetOrders(Guid pizzeriaId)
        {
            var pizzeriaOrders = await _context.Orders.Include(_ => _.PizzaOrders).ThenInclude(_ => _.Pizza).Where(_ => _.PizzeriaId == pizzeriaId).ToListAsync();

            return GenericEntityResult<List<Order>>.Ok(pizzeriaOrders);
        }
    }
}
