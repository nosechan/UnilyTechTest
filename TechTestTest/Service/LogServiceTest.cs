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
        [TestCase("1",null,"Test")]
        [TestCase("1", "2022-01-25", null)]
        public void LogMessageWithNullValue(string id, string date, string message)
        {
            Mock<IFileRepository> mockFileRepository = new();
            DateTime? datetime = date==null?null:DateTime.Parse(date);
            ILogService _logService = new LogService(mockFileRepository.Object);
            Assert.Throws<NullReferenceException>(() => _logService.LogMessage(id, new TechTest.Model.LogMessage() { Date = datetime, Message= message})) ;

        }

    }
}
