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
            driverBusinessService.AddDriver(driver);
            return NoContent();
        }

        [HttpGet(Name = "GetDriver")]

        public async Task<ActionResult<DriverDto>> Get(DriverDto driver)
        {

            driverBusinessService.AddDriver(driver);
            return NoContent();
        }
    }
}