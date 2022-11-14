using Microsoft.AspNetCore.Mvc;
using CarsAPI.Models.Dto;
using CarsAPI.Repository;
using Newtonsoft.Json.Linq;

namespace CarsAPI.Controllers;
[Route("api/cars")]

public class CarApiController: ControllerBase
{
    protected ResponseDto _response;
    private ICarRepository _carRepository;

    public CarApiController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
        _response = new ResponseDto();
    }
    
    [HttpGet]
    public async Task<object> get()
    {
        try
        {
            IEnumerable<CarDto> carDtos = await _carRepository.GetCars();
            _response.Result = carDtos;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>(){e.ToString()};
        }
        
        return _response;
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<object> Get(int id)
    {
        try
        {
            CarDto carDto = await _carRepository.GetCarById(id);
            _response.Result = carDto;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }
        
        return _response;
    }
    
    [HttpPost]
    public async Task<object> Post([FromBody] CarDto carDto)
    {
        try
        {
            JToken? regresApi = await _carRepository.CallAPI();
            int number = new Random().Next(0, 5);
            carDto.OwnerCar = regresApi[number]["first_name"] + " " + regresApi[number]["last_name"];
            CarDto model = await _carRepository.CreateUpdateCar(carDto);
            _response.Result = model;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }
        
        return _response;
    }
    
    [HttpPut]
    public async Task<object> Put([FromBody] CarDto carDto)
    {
        try
        {
            CarDto model = await _carRepository.CreateUpdateCar(carDto);
            _response.Result = model;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }
        
        return _response;

    }

    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _carRepository.DeleteCar(id);
            _response.IsSuccess = isSuccess;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
}