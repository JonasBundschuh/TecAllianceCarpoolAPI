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
        public async Task<ActionResult<List<DriverDto>>> Get()
        {
            return driverBusinessService.GetAllDrivers();
        }

        [HttpGet]
        [Route("/getDriverBy/{DriverId}")]
        public async Task<ActionResult<DriverDto>> GetDriverByID(int DriverId)
        {
            var result = driverBusinessService.GetDriverByID(DriverId);
            if (result == null)
            {
                return StatusCode(404, "UserID not found");
            }
            return result;
        }

        [HttpDelete]
        [Route("/deleteAllDrivers")]
        public async Task<ActionResult<DriverDto>> Delete(DriverDto driver)
        {
            driverBusinessService.DeleteAllDrivers();
            return StatusCode(200, "Successfully deleted all Drivers");
        }

        [HttpDelete]
        [Route("/deleteDriverByID/{DriverId}")]
        public async Task<ActionResult<DriverDto>> DeleteByID(int DriverId)
        {
            var result = driverBusinessService.DeleteDriverbyID(DriverId);
            if (result == null)
            {
                return StatusCode(404, "UserID not found");
            }
            return result;
        }

        
    }
}