using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;

namespace T_ecAllianceCarpoolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private DriverBusinessService driverBusinessService;

        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            driverBusinessService = new DriverBusinessService();
            _logger = logger;    
        }

        [HttpPost]
        public async Task<ActionResult<DriverDto>> Post(DriverDto driver)
        {
            driverBusinessService.AddDriver(driver.FreeSeats, driver.Smoke, driver.FullName, driver.StartLoc, driver.EndLoc, driver.TimeStart, driver.TimeEnd);
            return NoContent();
        }

        [HttpGet(Name = "GetDriver")]
        public async Task<ActionResult<DriverDto>> Get(DriverDto driver)
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
            return NoContent();
        }
    }
}