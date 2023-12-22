using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;

namespace StaffTrackApp.SAL.Services.Abstractions
{
    public interface ISalaryService
    {
        Task<ServiceValueResult<List<DepartmentInfo>>> GetAverageSalaryByDepartmentAsync();
        Task<ServiceValueResult<List<DepartmentsSalaryRange>>> GetDepartmentsSalaryRangesAsync();
        Task<ServiceValueResult<List<SalaryReport>>> GetSalaryReportAsync(GetSalaryReportRequest request);
        Task<ServiceResult> ExportEmployeesAsync(List<Employee> employees);
    }
}
