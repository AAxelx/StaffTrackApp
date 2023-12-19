

namespace StaffTrackApp.Common.Models
{
    public class DepartmentsSalaryRanges
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
    }
}
