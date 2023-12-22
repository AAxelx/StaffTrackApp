using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.SAL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _departmentRepository = repository;
        }

        public async Task<ServiceValueResult<List<Department>>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetDepartmentsAsync();

            return new ServiceValueResult<List<Department>>(departments);
        }
    }
}
