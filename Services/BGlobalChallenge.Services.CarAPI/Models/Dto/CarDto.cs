namespace CarsAPI.Models.Dto;

public class CarDto
{
    public int id { get; set; } 
    public string? Plate { get; set; }
    public string? Brand { get; set; }
    public string? ModelCar { get; set; }
    public int? Doors { get; set; }
    public string? OwnerCar { get; set; }
}