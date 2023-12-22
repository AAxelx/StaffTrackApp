using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;

namespace StaffTrackApp.SAL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ServiceValueResult<List<Department>>> GetDepartmentsAsync();
    }
}
