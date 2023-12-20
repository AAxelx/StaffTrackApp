

namespace StaffTrackApp.Common.Models.Requests
{
    public class GetSalaryReportRequest
    {
        public int? DepartmentId { get; set; } = null;
        public DateTime StartDate { get; set; } = new DateTime(1900, 1, 1);
        public DateTime EndDate { get; set; } = new DateTime(2025, 12, 31);
    }
}
