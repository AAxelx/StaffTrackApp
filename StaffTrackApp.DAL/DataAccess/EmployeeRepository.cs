using AutoMapper;
using StaffTrackApp.Common.Configurations;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using StaffTrackApp.Common.Models.Requests;


namespace StaffTrackApp.DAL.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IStoredProceduresHelper _proceduresHelper;
        private readonly IOptions<CompanyConfiguration> _companyConfiguration;
        private readonly IMapper _mapper;


        public EmployeeRepository(IStoredProceduresHelper proceduresHelper, IOptions<CompanyConfiguration> companyConfiguration,
            IMapper mapper)
        {
            _proceduresHelper = proceduresHelper;
            _companyConfiguration = companyConfiguration;
            _mapper = mapper;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var parameter = new SqlParameter("@EmployeeId", SqlDbType.Int) { Value = employeeId };
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetEmployeeById", [parameter]);

            var employee = _mapper.Map<Employee>(result.AsEnumerable().FirstOrDefault());
            return employee;
        }

        public async Task<List<Employee>> GetEmployeesAsync(GetEmployeesRequest request)
        {
            SqlParameter[] parameters =
            {
                new("@DepartmentId", SqlDbType.Int) { Value = request.DepartmentId.HasValue ? request.DepartmentId.Value : DBNull.Value },
                new("@Position", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(request.Position) ? DBNull.Value : request.Position },
                new("@Name", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(request.Name) ? DBNull.Value : request.Name }
            };

            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetEmployees", parameters);

            var employees = _mapper.Map<List<Employee>>(result.AsEnumerable());
            return employees;
        }

        public async Task<List<DepartmentInfo>> GetAverageSalaryByDepartmentAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetAverageSalaryByDepartment");

            var departmentInfos = _mapper.Map<List<DepartmentInfo>>(result.AsEnumerable());
            return departmentInfos;
        }

        public async Task<List<DepartmentsSalaryRange>> GetDepartmentsSalaryRangesAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetDepartmentsSalaryRanges");

            var departmentsSalaryRanges = _mapper.Map<List<DepartmentsSalaryRange>>(result.AsEnumerable());
            return departmentsSalaryRanges;
        }

        public async Task<CompanyInfo> GetCompanyInfoByIdAsync()
        {
            var parameter = new SqlParameter("@CompanyId", SqlDbType.Int) { Value = _companyConfiguration.Value.CompanyId };
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetCompanyInfoById", [parameter]);

            var companyInfo = _mapper.Map<CompanyInfo>(result.AsEnumerable().FirstOrDefault());
            return companyInfo;
        }

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

        public async Task UpdateEmployeeDetailsAsync(Employee updatedEmployee)
        {
            SqlParameter[] parameters =
            {
                new("@EmployeeId", SqlDbType.Int) { Value = updatedEmployee.Id },
                new("@DepartmentId", SqlDbType.Int) { Value = updatedEmployee.DepartmentId },
                new("@PositionId", SqlDbType.Int) { Value = updatedEmployee.PositionId },
                new("@FullName", SqlDbType.NVarChar) { Value = updatedEmployee.FullName },
                new("@Address", SqlDbType.NVarChar) { Value = updatedEmployee.Address },
                new("@Phone", SqlDbType.NVarChar) { Value = updatedEmployee.Phone },
                new("@DateOfBirth", SqlDbType.Date) { Value = updatedEmployee.DateOfBirth },
                new("@EmploymentDate", SqlDbType.Date) { Value = updatedEmployee.EmploymentDate },
                new("@Salary", SqlDbType.Decimal) { Value = updatedEmployee.Salary },
                new("@CompanyInfoId", SqlDbType.Int) { Value = updatedEmployee.CompanyInfoId },
            };

            await _proceduresHelper.ExecuteStoredProcedureAsync("UpdateEmployeeDetails", parameters);
        }

        public async Task RemoveDuplicateEmployeesAsync()
        {
            await _proceduresHelper.ExecuteStoredProcedureAsync("RemoveDuplicateEmployees");
        }
    }
}
