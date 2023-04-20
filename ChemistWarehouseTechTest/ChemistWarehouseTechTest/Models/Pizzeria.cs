using System.ComponentModel.DataAnnotations.Schema;

namespace ChemistWarehouseTechTest.Models
{
    [Table("Pizzeria")]
    public class Pizzeria
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
