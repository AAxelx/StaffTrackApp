

namespace StaffTrackApp.Common.Models.Requests
{
    public class ExportEmployeesRequest
    {
        public int? DepartmentId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
    }
}
