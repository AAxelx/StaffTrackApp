using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffTrackApp.Common.Models;
using StaffTrackApp.Common.Models.Requests;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.PL.Pages
{
    public class StaffModel : PageModel
    {
        public List<Employee> Employees { get; set; } = new List<Employee>
        {
            new Employee{ 
                Id = 1,
                Address = "Kek",
                DateOfBirth = new DateTime(),
                DepartmentId = 2,
                EmploymentDate = new DateTime(),
                FullName = "Kek",
                Phone = "066000",
                PositionId = 2,
                Salary = 50000 
            }
        };
        public Employee EmployeeForUpdate { get; set; }
        public string EmployeeName { get; set; }
        public List<Position> Positions { get; set; }
        public List<Department> Departments { get; set; }

        public IEmployeeService _employeeService { get; set; }
        public IDepartmentService _departmentService { get; set; }
        public IPositionService _positionService { get; set; }

        public StaffModel(IEmployeeService employeeService, IDepartmentService departmentService, IPositionService positionService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _positionService = positionService;
        }

        public async Task OnGetAsync(List<int?> departmentIds, List<int?> positionsIds, string name)
        {
            var getEmployeesRequest = new GetEmployeesRequest
            {
                DepartmentIds = departmentIds,
                PositionIds = positionsIds,
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
