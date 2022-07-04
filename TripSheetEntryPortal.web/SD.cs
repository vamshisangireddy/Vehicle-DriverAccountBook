using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripSheetEntryPortal.web
{
    public static class SD
    {
        public static string VehicleAPIBase { get; set;}
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
