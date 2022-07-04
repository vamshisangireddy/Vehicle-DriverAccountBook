using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApi.Models
{
    public class Vehicle
    {
        [Key]
        public string RegistrationNo { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Range(1, 500)]
        public string VehicleType { get; set; }
        public int NumberOfSeat { get; set; }
        public string AcAvailable { get; set; }
    }
}
