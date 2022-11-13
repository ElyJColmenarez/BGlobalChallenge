using System.ComponentModel.DataAnnotations;
namespace CarsAPI.Models;

public class Car
{
    [Key] public int id { get; set; } 
    [Range(1,8)] public string? Plate { get; set; }
    public string? Brand { get; set; }
    public string? ModelCar { get; set; }
    public int? Doors { get; set; }
    public string? OwnerCar { get; set; }
}