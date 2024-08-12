using System.ComponentModel.DataAnnotations;

namespace Core.Domains.Cars.Models;

public class CarDayInfo
{
    [Key]
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Car> Cars { get; set; } = new();
}
