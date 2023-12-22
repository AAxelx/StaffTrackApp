using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.PL.Pages
{
    public class IndexModel : PageModel
    {
        public string CompanyName { get; set; } = "Ukrposta";
        public string CompanyInfo { get; set; } = "We are one of the biggest company in Ukraine...";

        public IEmployeeService _service { get; set; }

        public IndexModel(IEmployeeService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {

        }
    }
}
