

namespace StaffTrackApp.Common.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Salary { get; set; }
        public int CompanyInfoId { get; set; }
    }
}
