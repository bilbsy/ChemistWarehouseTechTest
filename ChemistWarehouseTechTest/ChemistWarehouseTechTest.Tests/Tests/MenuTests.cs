using ChemistWarehouseTechTest.Models;
using ChemistWarehouseTechTest.Services.PizzaService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
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
            var menuService = new MenuService(_fixture.CreateContext());

            // Act
            var result = await menuService.GetMenuByLocation("Southbank");

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
            var menuService = new MenuService(_fixture.CreateContext());

            // Act
            var menu = (await menuService.GetMenuByLocation("Southbank")).Data;

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
