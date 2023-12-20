using AutoMapper;
using StaffTrackApp.Common.Enums;
using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.SAL.Helpers;
using StaffTrackApp.SAL.Helpers.Abstractions;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.SAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITextFileWriter _textFileWriter;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, ITextFileWriter textFileWriter,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _textFileWriter = textFileWriter;
            _mapper = mapper;
        }

        public async Task<ServiceValueResult<Employee>> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            return new ServiceValueResult<Employee>(employee);
        }

        public async Task<ServiceValueResult<List<Employee>>> GetEmployeesAsync(GetEmployeesRequest request)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(request);

            return new ServiceValueResult<List<Employee>>(employees);
        }

        public async Task<ServiceValueResult<List<DepartmentInfo>>> GetAverageSalaryByDepartmentAsync()
        {
            var departmentInfos = await _employeeRepository.GetAverageSalaryByDepartmentAsync();

            return new ServiceValueResult<List<DepartmentInfo>>(departmentInfos);
        }

        public async Task<ServiceValueResult<List<DepartmentsSalaryRange>>> GetDepartmentsSalaryRangesAsync()
        {
            var departmentsSalaryRanges = await _employeeRepository.GetDepartmentsSalaryRangesAsync();

            return new ServiceValueResult<List<DepartmentsSalaryRange>>(departmentsSalaryRanges);
        }

        public async Task<ServiceValueResult<CompanyInfo>> GetCompanyInfoAsync()
        {
            var companyInfo = await _employeeRepository.GetCompanyInfoByIdAsync();

            return new ServiceValueResult<CompanyInfo>(companyInfo);
        }

        public async Task<ServiceValueResult<List<SalaryReport>>> GetSalaryReportAsync(GetSalaryReportRequest request)
        {
            var salaryReports = await _employeeRepository.GetSalaryReportAsync(request);

            return new ServiceValueResult<List<SalaryReport>>(salaryReports);
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

        public async Task<ServiceResult> ExportEmployeesAsync(List<Employee> employees)
        {
            var stringEmployeesList = employees.ToFormattedString();
            var isSuccess = await _textFileWriter.WriteToFileAsync(stringEmployeesList);

            if (isSuccess)
            {
                return new ServiceResult(ResponseType.InternalServerError);
            }

            return new ServiceResult(ResponseType.Ok);
        }
    }
}
