using Microsoft.EntityFrameworkCore;
using ReactCsharpExperienceProof.Models;

namespace ReactCsharpExperienceProof;

public class PizeriaContext : DbContext
{
    public PizeriaContext(DbContextOptions<PizeriaContext> options) : base(options)
    {
    }

    public virtual DbSet<Pizzeria> Pizzerias { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizzeria>().HasKey(_ => _.Id);

        modelBuilder.Entity<Pizza>().HasKey(_ => _.Id);
        modelBuilder.Entity<Pizza>().Property(_ => _.Toppings)
            .HasConversion(
                v => string.Join(',', v ?? new List<string>()),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

        modelBuilder.Entity<PizzaOrder>().Property(_ => _.AdditionalToppings)
            .HasConversion(
                v => string.Join(',', v ?? new List<string>()),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

        var prestonPizzeria = new Pizzeria
        {
            Id = Guid.NewGuid(),
            Name = "Preston Pizzeria",
            Location = "Preston"
        };

        var southbankPizzeria = new Pizzeria
        {
            Id = Guid.NewGuid(),
            Name = "Southbank Pizzeria",
            Location = "Southbank"
        };

        modelBuilder.Entity<Pizzeria>().HasData(
            prestonPizzeria,
            southbankPizzeria
        );

        modelBuilder.Entity<Pizza>().HasData(
            new Pizza
            {
                Id = Guid.NewGuid(),
                Name = "Capricciosa",
                Toppings = new List<string> { "Cheese", "Ham", "Mushrooms", "Olives" },
                Price = 20,
                PizzeriaId = prestonPizzeria.Id
            },
            new Pizza
            {
                Id = Guid.NewGuid(),
                Name = "Mexicana",
                Toppings = new List<string> { "Cheese", "Salami", "Capiscum", "Chilli" },
                Price = 18,
                PizzeriaId = prestonPizzeria.Id
            },
            new Pizza
            {
                Id = Guid.NewGuid(),
                Name = "Margherita",
                Toppings = new List<string> { "Cheese", "Spinach", "Ricotta", "Cherry Tomatoes" },
                Price = 22,
                PizzeriaId = prestonPizzeria.Id
            },
            new Pizza
            {
                Id = Guid.NewGuid(),
                Name = "Capricciosa",
                Toppings = new List<string> { "Cheese", "Ham", "Mushrooms", "Olives" },
                Price = 20,
                PizzeriaId = southbankPizzeria.Id
            },
            new Pizza
            {
                Id = Guid.NewGuid(),
                Name = "Vegetarian",
                Toppings = new List<string> { "Cheese", "Mushrooms", "Capiscum", "Onion", "Olives" },
                Price = 17,
                PizzeriaId = southbankPizzeria.Id
            }
        );
    }
}