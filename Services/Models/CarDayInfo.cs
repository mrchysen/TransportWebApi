using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class CarDayInfo
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Car> Cars { get; set; } = new();
}
