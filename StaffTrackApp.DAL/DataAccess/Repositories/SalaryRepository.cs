using AutoMapper;
using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace StaffTrackApp.DAL.DataAccess.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly IStoredProceduresHelper _proceduresHelper;
        private readonly IMapper _mapper;

        public SalaryRepository(IStoredProceduresHelper proceduresHelper, IMapper mapper)
        {
            _proceduresHelper = proceduresHelper;
            _mapper = mapper;
        }

        public async Task<List<DepartmentInfo>> GetAverageSalaryByDepartmentAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetAverageSalaryByDepartments");

            var departmentInfos = _mapper.Map<List<DepartmentInfo>>(result.AsEnumerable());
            return departmentInfos;
        }

        public async Task<List<DepartmentsSalaryRange>> GetDepartmentsSalaryRangesAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetDepartmentsSalaryRanges");

            var departmentsSalaryRanges = _mapper.Map<List<DepartmentsSalaryRange>>(result.AsEnumerable());
            return departmentsSalaryRanges;
        }

        //public async Task<string> GetCompanyInfoByIdAsync()
        //{
        //    var parameter = new SqlParameter("@CompanyId", SqlDbType.Int) { Value = _companyConfiguration.Value.CompanyId };
        //    var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetCompanyInfoById", [parameter]);

        //    return result != null ? result.Rows[0]["CompanyInfo"].ToString() : string.Empty;
        //}

        public async Task<List<SalaryReport>> GetSalaryReportAsync(GetSalaryReportRequest request)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@DepartmentId", SqlDbType.Int) { Value = request.DepartmentId.HasValue ? request.DepartmentId : DBNull.Value },
                new SqlParameter("@StartDate", SqlDbType.Date) { Value = request.StartDate },
                new SqlParameter("@EndDate", SqlDbType.Date) { Value = request.EndDate }
            };

            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetSalaryReport", parameters.ToArray());

            var salaryReports = _mapper.Map<List<SalaryReport>>(result.AsEnumerable());
            return salaryReports;
        }
    }
}
