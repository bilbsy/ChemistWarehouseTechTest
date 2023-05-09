using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactCsharpExperienceProof.Models;

public class PizzaOrder
{
    [Required] public Guid Id { get; set; }

    [ForeignKey("PizzaId")] public Guid PizzaId { get; set; }

    public Pizza? Pizza { get; set; }

    public List<string>? AdditionalToppings { get; set; }

    public int? Amount { get; set; }
}