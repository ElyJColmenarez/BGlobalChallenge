using AutoMapper;
using CarsAPI.Models;
using CarsAPI.Models.Dto;

namespace CarsAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CarDto, Car>();
            config.CreateMap<Car, CarDto>();
        });

        return mappingConfig;
    }
}