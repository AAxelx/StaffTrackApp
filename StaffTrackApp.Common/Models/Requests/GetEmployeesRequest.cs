

namespace StaffTrackApp.Common.Models.Requests
{
    public class GetEmployeesRequest
    {
        public int? DepartmentId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
    }
}
