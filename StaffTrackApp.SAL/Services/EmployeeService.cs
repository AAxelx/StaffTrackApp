using StaffTrackApp.Common.Enums;
using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.SAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
       
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ServiceValueResult<Employee>> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);//add check for 404

            return new ServiceValueResult<Employee>(employee);
        }

        public async Task<ServiceValueResult<List<Employee>>> GetEmployeesAsync(GetEmployeesRequest request)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(request);

            return new ServiceValueResult<List<Employee>>(employees);
        }

        public async Task<ServiceResult> UpdateEmployeeDetailsAsync(Employee updatedEmployee)
        {
            await _employeeRepository.UpdateEmployeeDetailsAsync(updatedEmployee);

            return new ServiceResult(ResponseType.Ok);
        }

        public async Task<ServiceResult> RemoveDuplicateEmployeesAsync()
        {
            await _employeeRepository.RemoveDuplicateEmployeesAsync();

            return new ServiceResult(ResponseType.Ok);
        }
    }
}
