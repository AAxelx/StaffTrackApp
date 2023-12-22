using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<List<Employee>> GetEmployeesAsync(GetEmployeesRequest request);
        Task UpdateEmployeeDetailsAsync(Employee updatedEmployee);
        Task RemoveDuplicateEmployeesAsync();
    }
}
