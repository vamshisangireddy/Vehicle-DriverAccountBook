using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.DbContexts;
using VehicleApi.Models;
using VehicleApi.Models.Dto;

namespace VehicleApi.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _db;
       private IMapper _mapper;
        public VehicleRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> DeleteVehicle(String RegistrationNo)
        {
            try
            {
                Vehicle vehicle = await _db.VehicleTable.FirstOrDefaultAsync(u => u.RegistrationNo == RegistrationNo);
                if(vehicle==null)
                {
                    return false;
                }
                _db.VehicleTable.Remove(vehicle);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<VehicleDto> GetVehicleByValue(string ValueGiven)
        {
            Vehicle Vehicle = await _db.VehicleTable.Where(x => x.RegistrationNo == ValueGiven || x.VehicleType == ValueGiven).FirstOrDefaultAsync();
            return _mapper.Map<VehicleDto>(Vehicle);
        }

        //public async Task<VehicleDto> GetVehiclesByType(string VehicleType)
        //{
        //    Vehicle Vehicle = await _db.VehicleTable.Where(x => x.VehicleType == VehicleType).FirstOrDefaultAsync();
        //    return _mapper.Map<VehicleDto>(Vehicle);
        //}

        public async Task<IEnumerable<VehicleDto>> GetVehicles()
        {
            List<Vehicle> VehicleList = await _db.VehicleTable.ToListAsync();
            return _mapper.Map<List<VehicleDto>>(VehicleList);
        }

        public async Task<VehicleDto> UpdateVehicle(/*string RegistrationNo, string VehicleType,*/VehicleDto vehicleDto)
        {
            Vehicle vehicle = _mapper.Map<VehicleDto, Vehicle>(vehicleDto);
            _db.VehicleTable.Update(vehicle);
            await _db.SaveChangesAsync();
            return _mapper.Map<Vehicle, VehicleDto>(vehicle);
            //var _vehicle = _db.VehicleTable.FirstOrDefault(n => n.RegistrationNo == RegistrationNo && n.VehicleType == VehicleType);
            //if (_vehicle != null)
            //{
            //}
        }
        public async Task<VehicleDto> AddVehicle(VehicleDto vehicleDto)
        {
            Vehicle vehicle = _mapper.Map<VehicleDto, Vehicle>(vehicleDto);
            _db.VehicleTable.Add(vehicle);
            await _db.SaveChangesAsync();
            return _mapper.Map<Vehicle, VehicleDto>(vehicle);
        }
    }
}
