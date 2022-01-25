using Moq;
using NUnit.Framework;
using System;
using TechTest.Repository;
using TechTest.Service;

namespace TechTestTest.Service
{
    public class LogServiceTest
    {
        [Test]
        [TestCase("1", null, "Test")]
        [TestCase("1", "2022-01-25", null)]
        public void LogMessageWithNullValue(string id, string date, string message)
        {
            Mock<IFileRepository> mockFileRepository = new();
            ILogService _logService = new LogService(mockFileRepository.Object);
            Assert.Throws<NullReferenceException>(() => _logService.LogMessage(id, new TechTest.Model.LogMessage() { Date = date, Message = message }));
        }

        [Test]
        [TestCase("2022/1/1")]
        public void LogMessageWithInvalidDateFormat(string date)
        {
            Mock<IFileRepository> mockFileRepository = new();
            ILogService _logService = new LogService(mockFileRepository.Object);
            Assert.Throws<Exception>(() => _logService.LogMessage("1", new TechTest.Model.LogMessage() { Date = date, Message = "Test" }), "Invalid date format");
        }
        [Test]
        [TestCase("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")]
        public void LogMessageWithLongMessage(string message)
        {
            Mock<IFileRepository> mockFileRepository = new();
            ILogService _logService = new LogService(mockFileRepository.Object);
            Assert.Throws<OverflowException>(() => _logService.LogMessage("1", new TechTest.Model.LogMessage() { Date = "2022-01-01", Message = message }));
        }
    }
}
