using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Services.OrderingService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistWarehouseTechTest.Tests.Tests
{
    public class OrderingTests : IClassFixture<CWDbContextSeedDataFixture>
    {
        CWDbContextSeedDataFixture _fixture { get; set; }
        public OrderingTests(CWDbContextSeedDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetOrders()
        {
            // Arrange
            var context = _fixture.CreateContext();
            var orderingService = new OrderingService(context);
            var pizzeria = (await new PizzeriaService(context).GetPizzeriasList()).Data?.FirstOrDefault(_ => _.Name == "Southbank Pizzeria");

            if (pizzeria == null)
                throw new Exception("Pizzeria not found for Order tests");

            // Act
            var orders = await orderingService.GetOrders(pizzeria.Id);

            // Assert
            Assert.NotNull(orders);
            Assert.NotNull(orders.Data);
            Assert.Contains(orders.Data, d => "James B" == d.Name);
            Assert.Contains(orders.Data, d => "Capricciosa" == d.PizzaOrders?.FirstOrDefault()?.Pizza?.Name);
        }

        [Fact]
        public async Task AddOrder()
        {
            // Arrange
            var context = _fixture.CreateContext();
            var orderingService = new OrderingService(context);
            var pizzeriaService = new PizzeriaService(context);
            var pizzeriaId = (await pizzeriaService.GetPizzeriasList()).Data.FirstOrDefault(_ => _.Name == "Southbank Pizzeria").Id;
            var pizza = await context.Pizzas.FirstOrDefaultAsync(_ => _.Name == "Capricciosa" && _.PizzeriaId == pizzeriaId);

            var order =
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Name = "James B",
                    PizzaOrders = new List<PizzaOrder>
                    {
                        new PizzaOrder ()
                        {
                            Id = Guid.NewGuid(),
                            Pizza = pizza,
                            Amount = 5
                        }
                    }
                };

            // Act
            var result = (await orderingService.OrderPizzas(order));

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Equal(result?.Data?.Name, order.Name);
            Assert.True(result?.Data?.PizzaOrders?.Where(_ => _.Pizza?.Name == "Capricciosa") != null);
        }
    }
}
