using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactCsharpExperienceProof.Models;

[Table("Pizzeria")]
public class Pizzeria
{
    [Required] public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }
}