using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;

namespace StaffTrackApp.SAL.Services.Abstractions
{
    public interface IPositionService
    {
        Task<ServiceValueResult<List<Position>>> GetPositionsAsync();
    }
}
