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
            if (logMessage == null || logMessage.Date==null || logMessage.Message == null)
            {
                throw new NullReferenceException();
            }
            if (logMessage.Message!=null && logMessage.Message.Length > 255)
            {
                throw new OverflowException();
            }
            _fileRepository.AddMessage(id, logMessage.Date.Value, logMessage.Message??"");
            
        }
    }
}
