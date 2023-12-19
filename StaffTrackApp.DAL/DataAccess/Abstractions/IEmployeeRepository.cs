using StaffTrackApp.Common.Models;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int employeeId);
        Task<List<Employee>> GetEmployees(int? departmentId, string position, string name);
        Task<List<DepartmentInfo>> GetAverageSalaryByDepartmentAsync();
        Task<List<DepartmentsSalaryRanges>> GetDepartmentsSalaryRangesAsync();
        Task<CompanyInfo> GetCompanyInfoByIdAsync();
        Task<List<SalaryReport>> GetSalaryReport(int? departmentId = null, DateTime? startDate = null, DateTime? endDate = null);
        Task UpdateEmployeeDetails(Employee updatedEmployee);
        Task RemoveDuplicateEmployeesAsync();
    }
}
