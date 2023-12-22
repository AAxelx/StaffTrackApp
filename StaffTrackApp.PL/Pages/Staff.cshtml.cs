using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.PL.Pages
{
    public class StaffModel : PageModel
    {
        public List<Employee> Employees { get; set; }
        public Employee EmployeeForUpdate { get; set; }
        public string EmployeeName { get; set; }
        public List<Position> Positions { get; set; }
        public List<Department> Departments { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<int?> SelectedDepartmentIds { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<int?> SelectedPositionIds { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedName { get; set; }

        public IEmployeeService _employeeService { get; set; }
        public IDepartmentService _departmentService { get; set; }
        public IPositionService _positionService { get; set; }

        public StaffModel(IEmployeeService employeeService, IDepartmentService departmentService, IPositionService positionService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _positionService = positionService;
        }

        public async Task OnGetAsync(List<int?> departmentIds, List<int?> positionIds, string name)
        {
            var getEmployeesRequest = new GetEmployeesRequest
            {
                DepartmentIds = departmentIds,
                PositionIds = positionIds,
                Name = name
            };

            var employees = await _employeeService.GetEmployeesAsync(getEmployeesRequest);
            var departments = await _departmentService.GetDepartmentsAsync();
            var positions = await _positionService.GetPositionsAsync();

            Departments = departments.Value;
            Positions = positions.Value;
            Employees = employees.Value;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var result = _employeeService.UpdateEmployeeDetailsAsync(employee);

        }
    }
}
