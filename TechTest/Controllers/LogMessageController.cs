using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTest.Model;
using TechTest.Service;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogMessageController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public LogMessageController(ILogService logService)
        {
            _logService = logService;
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult LogMessage([FromRoute] string id,[FromBody] LogMessage logMessage) 
        {
            try
            {
                _logService.LogMessage(id, logMessage);

                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return BadRequest(e.Message);
            }
        }
    }
}
