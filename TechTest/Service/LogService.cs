using System.Globalization;
using TechTest.Model;
using TechTest.Repository;

namespace TechTest.Service
{
    public class LogService : ILogService
    {
        private readonly IFileRepository _fileRepository;
        public LogService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public void LogMessage(string id, LogMessage logMessage)
        {
            if (logMessage == null || string.IsNullOrEmpty(logMessage.Date) || logMessage.Message == null)
            {
                throw new NullReferenceException();
            }
            if (logMessage.Message != null && logMessage.Message.Length > 255)
            {
                throw new OverflowException();
            }
            DateTime dateTime;
            if (!DateTime.TryParseExact(logMessage.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                throw new Exception($"Invalid date format");
            }
            _fileRepository.AddMessage(id, logMessage.Date, logMessage.Message ?? "");

        }
    }
}
