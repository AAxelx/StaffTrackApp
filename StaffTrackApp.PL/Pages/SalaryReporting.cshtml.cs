using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffTrackApp.Common.Models;

namespace StaffTrackApp.PL.Pages
{
    public class SalaryReportingModel : PageModel
    {
        public List<SalaryReport> Reports { get; set; }

        public SalaryReportingModel()
        {

        }

        public void OnGet()
        {

        }
    }
}
