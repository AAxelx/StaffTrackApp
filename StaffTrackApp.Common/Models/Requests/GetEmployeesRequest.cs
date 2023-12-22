

namespace StaffTrackApp.Common.Models.Requests
{
    public class GetEmployeesRequest
    {
        public List<int?> DepartmentIds { get; set; } = null;
        public List<int?> PositionIds { get; set; } = null;
        public string Name { get; set; } = null;
    }
}
