using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;

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

        /// <summary>
        /// Function to add a Driver
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        /// <response code= "200">Successfully added Adds a new Driver</response>
        /// <response code= "400">Gets</response>
        [HttpPost]
        [Route("/postDriver")]
        public async Task<ActionResult<DriverDto>> Post(DriverDto driver)
        {
            driverBusinessService.AddDriver(driver);
            return StatusCode(200, "successfully added new Carpool");
        }

        /// <summary>
        /// Function to get/display all Drivers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/getDriver")]
        public async Task<ActionResult<List<DriverDto>>> Get()
        {
            return driverBusinessService.GetAllDrivers();
        }

        /// <summary>
        /// Function to get / display a Driver with the ID chosen by the User
        /// </summary>
        /// <param name="DriverId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Function to delete all Drivers
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/deleteAllDrivers")]
        public async Task<ActionResult<DriverDto>> Delete(DriverDto driver)
        {
            driverBusinessService.DeleteAllDrivers();
            return StatusCode(200, "Successfully deleted all Drivers");
        }


        /// <summary>
        /// Function to delete a Driver with the ID chosen by the User
        /// </summary>
        /// <param name="DriverId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/deleteDriverByID/{DriverId}")]
        public async Task<ActionResult<DriverDto>> DeleteByID(int Id)
        {
            driverBusinessService.DeleteDriverbyID(Id);
            return StatusCode(200, "Successfully deleted the driver with the ID {Id");
        }

        /// <summary>
        /// Edit information of an added Driver (chosen with the ID given by the User)
        /// </summary>
        /// <param name="DriverID"></param>
        /// <param name="newDriverName"></param>
        /// <param name="NowSmoker"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/editDriverbyID")]
        public async Task<ActionResult<DriverDto>> EditDriverByID(int DriverID, string newDriverName, string NowSmoker)
        {
            var result = driverBusinessService.EditDriverByID(DriverID, newDriverName, NowSmoker);
            if (result == null)
            {
                return StatusCode(404, "UserID not found.");
            }
            return result;
        }


    }
}