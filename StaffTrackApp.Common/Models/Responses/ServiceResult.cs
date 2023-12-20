using StaffTrackApp.Common.Enums;

namespace StaffTrackApp.Common.Models.Responses
{
    public class ServiceResult
    {
        public ResponseType ResponseType { get; set; }

        public ServiceResult(ResponseType type)
        {
            ResponseType = type;
        }
    }
}
