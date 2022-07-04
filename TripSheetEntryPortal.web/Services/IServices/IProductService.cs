using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSheetEntryPortal.Models;

namespace TripSheetEntryPortal.web.Services.IServices
{
    interface IProductService
    {
        Task<T> GetAllVehiclesAsync<T>();
        Task<T> GetVehicleByIdAsync<T>(string id);
        Task<T> AddvehicleAsync<T>(VehicleDto vehicleDto);
        Task<T> UpdateVehicleAsync<T>(VehicleDto vehicleDto);
        Task<T> DeleteProductAsync<T>(string id);

    }
}
