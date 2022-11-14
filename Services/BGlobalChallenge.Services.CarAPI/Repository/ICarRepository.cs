using CarsAPI.Models.Dto;
using Newtonsoft.Json.Linq;

namespace CarsAPI.Repository;

public interface ICarRepository
{
    Task<IEnumerable<CarDto>> GetCars();
    Task<CarDto> GetCarById(int id);
    Task<CarDto> CreateUpdateCar(CarDto carDto);
    Task<bool> DeleteCar(int id);

    Task<JToken?> CallAPI();
}