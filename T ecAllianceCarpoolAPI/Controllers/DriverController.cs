using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;
using TecAlliance.Carpool.Data.Services;

namespace T_ecAllianceCarpoolAPI.Controllers
{
    [ApiController]
    [Route("DriverController")]
    public class DriverController : ControllerBase
    {
        private DriverBusinessService driverBusinessService;
        private DriverdataService driverdataService;

        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            driverBusinessService = new DriverBusinessService();
            _logger = logger;
        }

        [HttpPost]
        [Route("/postDriver")]
        public async Task<ActionResult<DriverDto>> Post(DriverDto driver)
        {
            driverBusinessService.AddDriver(driver);
            return StatusCode(200, "successfully added new Carpool");
        }

        [HttpGet]
        [Route("/getDriver")]
        public async Task<ActionResult<DriverDto>> Get(DriverDto driver)
        {
            return NoContent();
        }

        [HttpDelete]
        [Route("/deleteAllDrivers")]
        public async Task<ActionResult<DriverDto>> Delete(DriverDto driver)
        {
            driverBusinessService.DeleteAllDrivers(driver);
            return StatusCode(200, "Successfully deleted all Drivers");
        }
    }
}