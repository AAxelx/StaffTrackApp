

namespace StaffTrackApp.Common.Entities
{
    public class PositionEntity
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
