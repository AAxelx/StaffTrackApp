using AutoMapper;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace StaffTrackApp.DAL.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IStoredProceduresHelper _proceduresHelper;
        private readonly IMapper _mapper;


        public EmployeeRepository(string connectionString, IMapper mapper)
        {
            _proceduresHelper = new StoredProceduresHelper(connectionString);
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetEmployeesWithFilters(int? departmentId, string position, string name)
        {
            SqlParameter[] parameters =
                {
                    new("@DepartmentId", SqlDbType.Int) { Value = departmentId.HasValue ? departmentId.Value : DBNull.Value },
                    new("@Position", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(position) ? DBNull.Value : position },
                    new("@Name", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(name) ? DBNull.Value : name }
                };

            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetAllEmployeesWithFilters", parameters);

            var employees = _mapper.Map<List<Employee>>(result.AsEnumerable());
            return employees;
        }

        public async Task<List<DepartmentInfo>> GetAverageSalaryByDepartment()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetAverageSalaryByDepartment");

            var departmentInfos = _mapper.Map<List<DepartmentInfo>>(result.AsEnumerable());
            return departmentInfos;
        }

        public async Task<List<DepartmentsSalaryRanges>> GetDepartmentsSalaryRanges()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetDepartmentsSalaryRanges");

            var departmentsSalaryRanges = _mapper.Map<List<DepartmentsSalaryRanges>>(result.AsEnumerable());
            return departmentsSalaryRanges;
        }

        public async Task RemoveDuplicateEmployees()
        {
            await _proceduresHelper.ExecuteStoredProcedureAsync("RemoveDuplicateEmployees");
        }
    }
}
