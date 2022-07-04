using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Models.Dto;
using VehicleApi.Repository;

namespace VehicleApi.Controllers
{
    [Route("api/vehicles")]
    public class VehicleAPIController : ControllerBase
    {
        protected ResponseDto _response;
        IVehicleRepository _vehicleRepository;
        public VehicleAPIController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
       
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<VehicleDto> vehicleDtos = await _vehicleRepository.GetVehicles();
                _response.Result = vehicleDtos;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()};
            }
            return _response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(string id)
        {
                try
                {
                    VehicleDto vehicleDto = await _vehicleRepository.GetVehicleByValue(id);
                    _response.Result = vehicleDto;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { ex.ToString() };
                }
                return _response;
          
        }
        [HttpPut]
        [Route("addVehicle")]
        public async Task<object> Post([FromBody] VehicleDto vehicleDto)
        {
            try
            {
                VehicleDto model = await _vehicleRepository.AddVehicle(vehicleDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [Route("updateVehicle")]
        public async Task<object> Put(/*string RegistrationNo, string VehicleType,*/[FromBody] VehicleDto vehicleDto)
        {
            
            try
            {
                VehicleDto model = await _vehicleRepository.UpdateVehicle(/*RegistrationNo,VehicleType,*/ vehicleDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete]
        [Route("deleteVehicles")]
        public async Task<object> Delete(string RegistrationNo)
        {
            try
            {
                bool isSuccess = await _vehicleRepository.DeleteVehicle(RegistrationNo);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
    }
}
