using TechTest.Model;

namespace TechTest.Service
{
    public interface ILogService
    {
        void LogMessage(string id, LogMessage logMessage);
    }
}
