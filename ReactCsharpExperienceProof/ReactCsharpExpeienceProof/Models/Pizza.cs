using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactCsharpExperienceProof.Models;

[Table("Pizza")]
public class Pizza
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int Price { get; set; }

    [Required] public Guid PizzeriaId { get; set; }

    [ForeignKey("PizzeriaId")] public Pizzeria? Pizzeria { get; set; }

    public List<string>? Toppings { get; set; }
}