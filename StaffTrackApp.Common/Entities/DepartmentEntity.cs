

namespace StaffTrackApp.Common.Entities
{
    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
