

namespace StaffTrackApp.SAL.Helpers.Abstractions
{
    public interface ITextFileWriter
    {
        Task<bool> WriteToFileAsync(List<string> data);
    }
}
