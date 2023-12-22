using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.Common.Models;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface ISalaryRepository
    {
        Task<List<DepartmentInfo>> GetAverageSalaryByDepartmentAsync();
        Task<List<DepartmentsSalaryRange>> GetDepartmentsSalaryRangesAsync();
        Task<List<SalaryReport>> GetSalaryReportAsync(GetSalaryReportRequest request);
    }
}
