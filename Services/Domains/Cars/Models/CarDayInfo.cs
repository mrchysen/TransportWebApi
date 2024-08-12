using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domains.Cars.Models;

public class CarDayInfo
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("date")]
    public DateOnly Date { get; set; }
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("cars")]
    public List<Car> Cars { get; set; } = new();
}
