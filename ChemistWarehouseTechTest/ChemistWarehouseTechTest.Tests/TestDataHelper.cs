using ChemistWarehouseTechTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehouseTechTest.Tests
{
    public class CWDbContextSeedDataFixture
    {
        private const string ConnectionString = "Server=localhost;Database=TestDb;Trusted_Connection=True;Encrypt=False;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public CWDbContext CreateContext()
            => new(
                new DbContextOptionsBuilder<CWDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
        public CWDbContextSeedDataFixture() {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.AddRange(GetPizzerias());
                        context.SaveChanges();
                        context.AddRange(GetOrders(context));
                        context.AddRange(GetPizzas(context));
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }

        }
        public static List<Pizza> GetPizzas(CWDbContext context)
        {
            var southbankPizzeriaId = context.Pizzerias.FirstOrDefault(_ => _.Name == "Southbank Pizzeria").Id;
            var prestonPizzeriaId = context.Pizzerias.FirstOrDefault(_ => _.Name == "Preston Pizzeria").Id;

            return new List<Pizza>()
            {
                new Pizza()
                {
                    Id = Guid.NewGuid(),
                    Name = "Capricciosa",
                    Toppings = new List<string>() { "Cheese", "Ham", "Mushrooms", "Olives" },
                    Price = 20,
                    PizzeriaId = southbankPizzeriaId
                },
                new Pizza()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vegetarian",
                    Toppings = new List<string>() { "Cheese", "Mushrooms", "Capiscum", "Onion", "Olives" },
                    Price = 17,
                    PizzeriaId = southbankPizzeriaId
                },
                new Pizza()
                {
                    Id = Guid.NewGuid(),
                    Name = "Capricciosa",
                    Toppings = new List<string>() { "Cheese", "Ham", "Mushrooms", "Olives" },
                    Price = 20,
                    PizzeriaId = prestonPizzeriaId
                },
                new Pizza()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mexicana",
                    Toppings = new List<string>() { "Cheese", "Salami", "Capiscum", "Chilli" },
                    Price = 18,
                    PizzeriaId = prestonPizzeriaId
                },
                new Pizza()
                {
                    Id = Guid.NewGuid(),
                    Name = "Margherita",
                    Toppings = new List<string>() { "Cheese", "Spinach", "Ricotta", "Cherry Tomatoes" },
                    Price = 22,
                    PizzeriaId = prestonPizzeriaId
                }
            };
                    
        }

        public static List<Order> GetOrders(CWDbContext context)
        {
            var pizzeria = context.Pizzerias.FirstOrDefault(_ => _.Name == "Southbank Pizzeria");

            if(pizzeria == null )
                throw new Exception("Pizzeria not found for orders test.");

            var pizza = context.Pizzas.FirstOrDefault(_ => _.PizzeriaId == pizzeria.Id && _.Name == "Capricciosa");

            if(pizza == null )
                throw new Exception("Pizza not found.");

            return new List<Order>() { 
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Name = "James B",
                    PizzeriaId = pizzeria.Id,
                    PizzaOrders = new List<PizzaOrder>
                    { 
                        new PizzaOrder () 
                        { 
                            Id = Guid.NewGuid(), 
                            Amount = 5,
                            PizzaId = pizza.Id
                        }
                    }
                }
            };
        }

        public static List<Pizzeria> GetPizzerias()
        {
            var southbankPizzeriaId = Guid.NewGuid();
            var prestonPizzeriaId = Guid.NewGuid();

            return new List<Pizzeria>()
            {
                new Pizzeria()
                {
                    Id = southbankPizzeriaId,
                    Location = "Southbank",
                    Name = "Southbank Pizzeria"
                },
                new Pizzeria()
                {
                    Id = prestonPizzeriaId,
                    Name = "Preston Pizzeria",
                    Location = "Preston"
                }
            };
        }
    }
}
