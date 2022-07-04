using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Models.Dto;

namespace VehicleApi.Repository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleDto>> GetVehicles();
        //Task<VehicleDto> GetVehiclesByType(string VehicleType);
        //Task<VehicleDto> GetVehicleByRegistrationNo(string RegistrationNo);
        Task<VehicleDto> GetVehicleByValue(string valueGiven);
        Task<VehicleDto> UpdateVehicle(/*string RegistrationNo, string VehicleType,*/VehicleDto vehicleDto);
        Task<VehicleDto> AddVehicle(/*string VehicleType*/VehicleDto vehicleDto);
        Task<bool> DeleteVehicle(string RegistrationNo);

    }
}
