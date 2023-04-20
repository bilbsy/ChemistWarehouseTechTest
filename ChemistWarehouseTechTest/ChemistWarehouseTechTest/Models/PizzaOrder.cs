using System.ComponentModel.DataAnnotations.Schema;

namespace ChemistWarehouseTechTest.Models
{
    public class PizzaOrder
    {
        public Guid Id { get; set; }

        [ForeignKey("PizzaId")]
        public Guid PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public List<string> AdditionalToppings { get; set; }

        public int Amount { get; set; }
    }
}
