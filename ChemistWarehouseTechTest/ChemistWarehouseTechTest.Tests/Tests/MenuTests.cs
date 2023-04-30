using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Services.PizzaService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistWarehouseTechTest.Tests.Tests
{
    public class MenuTests : IClassFixture<CWDbContextSeedDataFixture>
    {
        CWDbContextSeedDataFixture _fixture { get; set; }

        public MenuTests(CWDbContextSeedDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetMenu()
        {
            // Arrange
            var context = _fixture.CreateContext();
            var menuService = new MenuService(context);
            var id = (await context.Pizzerias.FirstOrDefaultAsync(_ => _.Name == "Southbank Pizzeria")).Id;

            // Act
            var result = await menuService.GetMenuFromPizzeria(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Contains(result.Data, d => "Capricciosa" == d.Name);
            Assert.Equal(result.Data.FirstOrDefault(_ => _.Name == "Capricciosa")?.Price, 20);
        }

        [Fact]
        public async Task UpdateMenu()
        {
            // Arrange
            var context = _fixture.CreateContext();
            var menuService = new MenuService(context);
            var id = (await context.Pizzerias.FirstOrDefaultAsync(_ => _.Name == "Southbank Pizzeria")).Id;

            // Act
            var menu = (await menuService.GetMenuFromPizzeria(id)).Data;

            if (menu == null)
                throw new Exception("Can not get Southbank menu from menuservice in tests");

            menu.Add(new Pizza() { Name = "Hot Smoothity", PizzeriaId = menu.First().PizzeriaId, Price = 10000, Toppings = new List<string>() { "Hot Salami", "Jalepinos", "Pineapple" } });

            var result = await menuService.UpdateMenu(menu.First().PizzeriaId, menu);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Contains(result.Data, d => "Hot Smoothity" == d.Name);
            Assert.Equal(result.Data.FirstOrDefault(_ => _.Name == "Hot Smoothity")?.Price, 10000);
        }
    }
}
