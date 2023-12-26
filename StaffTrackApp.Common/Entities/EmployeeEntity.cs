

namespace StaffTrackApp.Common.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }
        public int PositionId { get; set; }
        public PositionEntity Position { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Salary { get; set; }
    }
}
