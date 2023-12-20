using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<List<Employee>> GetEmployeesAsync(GetEmployeesRequest request);
        Task<List<DepartmentInfo>> GetAverageSalaryByDepartmentAsync();
        Task<List<DepartmentsSalaryRange>> GetDepartmentsSalaryRangesAsync();
        Task<CompanyInfo> GetCompanyInfoByIdAsync();
        Task<List<SalaryReport>> GetSalaryReportAsync(GetSalaryReportRequest request);
        Task UpdateEmployeeDetailsAsync(Employee updatedEmployee);
        Task RemoveDuplicateEmployeesAsync();
    }
}
