using TechTest.Model;
using TechTest.Repository;

namespace TechTest.Service
{
    public class LogService : ILogService
    {
        private IFileRepository _fileRepository;
        public LogService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public void LogMessage(string id, LogMessage logMessage)
        {
            if (logMessage == null || logMessage.date==null || logMessage.message == null)
            {
                throw new NullReferenceException();
            }
            if (logMessage.message!=null && logMessage.message.Length > 255)
            {
                throw new OverflowException();
            }
            _fileRepository.AddMessage(id, logMessage.date.Value, logMessage.message??"");
            
        }
    }
}
