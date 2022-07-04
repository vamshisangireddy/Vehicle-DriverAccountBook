using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Models;
using VehicleApi.Models.Dto;

namespace VehicleApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VehicleDto, Vehicle>();
                config.CreateMap<Vehicle, VehicleDto>();
            });
            return mappingConfig;
        }
    }
}
