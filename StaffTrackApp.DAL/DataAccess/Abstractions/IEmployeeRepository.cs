using StaffTrackApp.Common.Models;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesWithFilters(int? departmentId, string position, string name);
        Task<List<DepartmentInfo>> GetAverageSalaryByDepartment();
        Task<List<DepartmentsSalaryRanges>> GetDepartmentsSalaryRanges();
        Task RemoveDuplicateEmployees();
    }
}
