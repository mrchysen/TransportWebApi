using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domains.Cars.Models;

[Table("car")]
public class Car
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("number")]
    public string Number { get; set; } = string.Empty;
    [Column("is_worked")]
    public bool IsWorked { get; set; } = false;
    [Column("fuel_begin")]
    public int FuelBegin { get; set; } = 0;
    [Column("fuel_end")]
    public int FuelEnd { get; set; } = 0;
    [Column("was_screen")]
    public bool WasScreen { get; set; } = false;
    [Column("was24km_et")]
    public bool Was24kmET { get; set; } = false;
    [Column("parking")]
    public List<int> Parking { get; set; } = new List<int>();
    [Column("add_information")]
    public List<string> AddInformation { get; set; } = new List<string>();

    public override string ToString()
    {
        return Number;
    }
}
