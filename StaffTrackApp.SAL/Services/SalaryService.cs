using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.Common.Enums;
using StaffTrackApp.SAL.Helpers;
using StaffTrackApp.SAL.Helpers.Abstractions;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.SAL.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly ITextFileWriter _textFileWriter;

        public SalaryService(ISalaryRepository salaryRepository, ITextFileWriter textFileWriter)
        {
            _salaryRepository = salaryRepository;
            _textFileWriter = textFileWriter;
        }

        public async Task<ServiceValueResult<List<DepartmentInfo>>> GetAverageSalaryByDepartmentAsync()
        {
            var departmentInfos = await _salaryRepository.GetAverageSalaryByDepartmentAsync();

            return new ServiceValueResult<List<DepartmentInfo>>(departmentInfos);
        }

        public async Task<ServiceValueResult<List<DepartmentsSalaryRange>>> GetDepartmentsSalaryRangesAsync()
        {
            var departmentsSalaryRanges = await _salaryRepository.GetDepartmentsSalaryRangesAsync();

            return new ServiceValueResult<List<DepartmentsSalaryRange>>(departmentsSalaryRanges);
        }

        public async Task<ServiceValueResult<List<SalaryReport>>> GetSalaryReportAsync(GetSalaryReportRequest request)
        {
            var salaryReports = await _salaryRepository.GetSalaryReportAsync(request);

            return new ServiceValueResult<List<SalaryReport>>(salaryReports);
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
