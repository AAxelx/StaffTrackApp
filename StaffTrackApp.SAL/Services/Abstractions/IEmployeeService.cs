using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;

namespace StaffTrackApp.SAL.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ServiceValueResult<Employee>> GetEmployeeByIdAsync(int employeeId);
        Task<ServiceValueResult<List<Employee>>> GetEmployeesAsync(GetEmployeesRequest request);
        Task<ServiceResult> UpdateEmployeeDetailsAsync(Employee updatedEmployee);
        Task<ServiceResult> RemoveDuplicateEmployeesAsync();
    }
}
