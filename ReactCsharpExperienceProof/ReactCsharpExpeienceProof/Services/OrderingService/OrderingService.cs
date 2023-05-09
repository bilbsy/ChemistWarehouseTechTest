using Microsoft.EntityFrameworkCore;
using ReactCsharpExperienceProof.Models;
using ReactCsharpExperienceProof.Results;

namespace ReactCsharpExperienceProof.Services.OrderingService;

public class OrderingService : IOrderingService
{
    private readonly PizeriaContext _context;

    public OrderingService(PizeriaContext context)
    {
        _context = context;
    }

    public async Task<GenericEntityResult<Order>> OrderPizzas(Order order)
    {
        var result = await _context.Orders.AddAsync(order);
        
        return GenericEntityResult<Order>.Ok(result.Entity);
    }

    public async Task<GenericEntityResult<List<Order>>> GetOrders(Guid pizzeriaId)
    {
        var pizzeriaOrders = await _context.Orders.Include(_ => _.PizzaOrders)!.ThenInclude(_ => _.Pizza)
            .Where(_ => _.PizzeriaId == pizzeriaId).ToListAsync();

        return GenericEntityResult<List<Order>>.Ok(pizzeriaOrders);
    }
}