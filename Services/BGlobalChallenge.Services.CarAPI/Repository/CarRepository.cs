using System.Collections;
using System.Dynamic;
using AutoMapper;
using CarsAPI.DbContexts;
using CarsAPI.Models;
using CarsAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarsAPI.Repository;

public class CarRepository:ICarRepository
{
    private readonly ApplicationDbContext _db;
    private readonly string _regresApi;
    private readonly string _param;
    private IMapper _mapper;

    public CarRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _regresApi = "https://reqres.in/api/users";
        _param = "users";
    }
    public async Task<IEnumerable<CarDto>> GetCars()
    {
        List<Car?> carList = await _db.Cars.ToListAsync();
        return _mapper.Map<List<CarDto>>(carList);
    }

    public async Task<CarDto> GetCarById(int id)
    {
        Car? car = await _db.Cars.Where(x => x.id == id).FirstOrDefaultAsync();
        return _mapper.Map<CarDto>(car);
    }

    public async Task<CarDto> CreateUpdateCar(CarDto carDto)
    {
        Car car = _mapper.Map<CarDto, Car>(carDto);
        if (car.id > 0)
        {
            _db.Cars.Update(car);
        }
        else
        {
            _db.Cars.Add(car);
        }

        await _db.SaveChangesAsync();
        return _mapper.Map<Car, CarDto>(car);
    }

    public async Task<bool> DeleteCar(int id)
    {
        try
        {
            Car? car = await _db.Cars.FirstOrDefaultAsync(u => u.id == id);
            if (car == null)
            {
                return false;
            }

            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public async Task<JToken?> CallAPI()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(_regresApi);

        HttpResponseMessage response = await httpClient.GetAsync(_regresApi);

        var HttpsResponse = await response.Content.ReadAsStringAsync();
        var JSONObject = JsonConvert.DeserializeObject<JObject>(HttpsResponse);
        return JSONObject["data"];
    }
}