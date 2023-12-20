using Microsoft.Extensions.Options;
using StaffTrackApp.Common.Configurations;
using StaffTrackApp.SAL.Helpers.Abstractions;

namespace StaffTrackApp.SAL.Helpers
{
    public class TextFileWriter : ITextFileWriter
    {
        private readonly IOptions<ExportConfiguration> _exportConfiguration;

        public TextFileWriter(IOptions<ExportConfiguration> exportConfiguration)
        {
            _exportConfiguration = exportConfiguration;
        }

        public async Task<bool> WriteToFileAsync(List<string> data)
        {
            var fileName = $"{DateTime.UtcNow:yyyyMMdd_HHmmss}_ExportedData.txt";
            var filePath = Path.Combine(_exportConfiguration.Value.ExportFilePath, fileName);

            using (var streamWriter = File.CreateText(filePath))
            {
                foreach (var line in data)
                {
                    await streamWriter.WriteLineAsync(line);
                }
            }

            return true;
        }
    }
}
