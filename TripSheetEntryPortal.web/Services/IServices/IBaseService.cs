using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSheetEntryPortal.Models;
using TripSheetEntryPortal.web.Models;

namespace TripSheetEntryPortal.web.Services.IServices
{
    interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
