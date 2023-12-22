using StaffTrackApp.Common.Models;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetPositionsAsync();
    }
}
