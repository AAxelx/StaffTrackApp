using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffTrackApp.Common.Models;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.PL.Pages
{
    public class EditEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public Employee Employee { get; set; }

        public EditEmployeeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);

            if (result.ResponseType == Common.Enums.ResponseType.Ok)
            {
                Employee = result.Value;
                return Page();
            }
            else
            {
                return RedirectToPage("Error");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeService.UpdateEmployeeDetailsAsync(Employee);

            return RedirectToPage("Staff");
        }
    }

}
