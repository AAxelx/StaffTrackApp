using AutoMapper;
using StaffTrackApp.Common.Configurations;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using StaffTrackApp.Common.Models.Requests;


namespace StaffTrackApp.DAL.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IStoredProceduresHelper _proceduresHelper;
        private readonly IMapper _mapper;

        public EmployeeRepository(IStoredProceduresHelper proceduresHelper, IMapper mapper)
        {
            _proceduresHelper = proceduresHelper;
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
            var departmentIdsParam = new SqlParameter("@DepartmentIds", SqlDbType.NVarChar);
            departmentIdsParam.Value = request.DepartmentIds != null && request.DepartmentIds.Any()
                ? string.Join(",", request.DepartmentIds)
                : DBNull.Value;

            var positionsParam = new SqlParameter("@PositionIds", SqlDbType.NVarChar);
            positionsParam.Value = request.PositionIds != null && request.PositionIds.Any()
                ? string.Join(",", request.PositionIds)
                : DBNull.Value;

            var nameParam = new SqlParameter("@Name", SqlDbType.NVarChar);
            nameParam.Value = string.IsNullOrEmpty(request.Name) ? DBNull.Value : request.Name;

            SqlParameter[] parameters = { departmentIdsParam, positionsParam, nameParam };

            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetEmployees", parameters);

            var employees = new List<Employee>();

            foreach (DataRow row in result.Rows)
            {
                var employee = new Employee
                {
                    Id = Convert.ToInt32(row["Id"]),
                    DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                    PositionId = Convert.ToInt32(row["PositionId"]),
                    FullName = row["FullName"].ToString(),
                    Address = row["Address"].ToString(),
                    Phone = row["Phone"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]).Date,
                    EmploymentDate = Convert.ToDateTime(row["EmploymentDate"]),
                    Salary = Convert.ToDecimal(row["Salary"])
                };

                employees.Add(employee);
            }

            return employees;
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
                new("@Salary", SqlDbType.Decimal) { Value = updatedEmployee.Salary }
            };

            await _proceduresHelper.ExecuteStoredProcedureAsync("UpdateEmployeeDetails", parameters);
        }

        public async Task RemoveDuplicateEmployeesAsync()
        {
            await _proceduresHelper.ExecuteStoredProcedureAsync("RemoveDuplicateEmployees");
        }
    }
}
