using AutoMapper;
using StaffTrackApp.Common.Configurations;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;


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

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            var parameter = new SqlParameter("@EmployeeId", SqlDbType.Int) { Value = employeeId };
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetEmployeeById", [parameter]);

            var employee = _mapper.Map<Employee>(result.AsEnumerable().FirstOrDefault());
            return employee;
        }

        public async Task<List<Employee>> GetEmployees(int? departmentId, string position, string name)
        {
            SqlParameter[] parameters =
                {
                    new("@DepartmentId", SqlDbType.Int) { Value = departmentId.HasValue ? departmentId.Value : DBNull.Value },
                    new("@Position", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(position) ? DBNull.Value : position },
                    new("@Name", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(name) ? DBNull.Value : name }
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

        public async Task<List<DepartmentsSalaryRanges>> GetDepartmentsSalaryRangesAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetDepartmentsSalaryRanges");

            var departmentsSalaryRanges = _mapper.Map<List<DepartmentsSalaryRanges>>(result.AsEnumerable());
            return departmentsSalaryRanges;
        }

        public async Task<CompanyInfo> GetCompanyInfoByIdAsync()
        {
            var parameter = new SqlParameter("@CompanyId", SqlDbType.Int) { Value = _companyConfiguration.Value.CompanyId };
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetCompanyInfoById", [parameter]);

            var companyInfo = _mapper.Map<CompanyInfo>(result.AsEnumerable().FirstOrDefault());
            return companyInfo;
        }

        public async Task<List<SalaryReport>> GetSalaryReport(int? departmentId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@DepartmentId", SqlDbType.Int) { Value = departmentId.HasValue ? departmentId.Value : DBNull.Value },
                new SqlParameter("@StartDate", SqlDbType.Date) { Value = startDate.HasValue ? startDate.Value : DBNull.Value },
                new SqlParameter("@EndDate", SqlDbType.Date) { Value = endDate.HasValue ? endDate.Value : DBNull.Value }
            };

            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetSalaryReport", parameters.ToArray());

            var salaryReports = _mapper.Map<List<SalaryReport>>(result.AsEnumerable());
            return salaryReports;
        }

        public async Task UpdateEmployeeDetails(Employee updatedEmployee)
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

        public async Task<List<Employee>> ExportEmployees(int? departmentId, string position, string name)
        {
            SqlParameter[] parameters =
                {
                    new("@DepartmentId", SqlDbType.Int) { Value = departmentId.HasValue ? departmentId.Value : DBNull.Value },
                    new("@Position", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(position) ? DBNull.Value : position },
                    new("@Name", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(name) ? DBNull.Value : name }
                };

            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetEmployees", parameters);

            //use helper for exporting to txt file
            //return employees;
        }

    }
}
