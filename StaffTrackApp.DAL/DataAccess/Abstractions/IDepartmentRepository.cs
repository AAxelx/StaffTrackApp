using StaffTrackApp.Common.Models;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentsAsync();
    }
}
