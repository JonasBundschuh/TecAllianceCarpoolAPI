using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;
using TecAlliance.Carpool.Data.Models;

namespace T_ecAllianceCarpoolAPI.Controllers
{
    [ApiController]
    [Route("CarpoolController")]
    public class CarpoolController : ControllerBase
    {
        private CarpoolBusinessService carpoolBusinessService;
        private readonly ILogger<CarpoolController> _logger;
        public CarpoolController(ILogger<CarpoolController> logger)
        {
            carpoolBusinessService = new CarpoolBusinessService();
            _logger = logger;
        }

        /// <summary>
        /// Function to add a Caprool
        /// </summary>
        /// <param name="carpool"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/postCarpool")]
        public async Task<ActionResult<CarpoolS>> Post(CarpoolDto carpool)
        {
            return carpoolBusinessService.AddCarpool(carpool);
            //return StatusCode(200, "successfully added new Carpool");
        }

        /// <summary>
        /// Function to get/display all added Carpools
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Gets all items/carpools</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/getAllCarpools")]
        public async Task<ActionResult<List<CarpoolDto>>> Get()
        {
            return carpoolBusinessService.GetAllCarpools();
        }

        /// <summary>
        /// Function to get/display the carpool matching the ID chosen by the user
        /// </summary>
        /// <param name="CarpoolId"></param>
        /// <returns></returns>
        /// <response code="200">Returns Carpool Item matching ID chosen by user>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/getCarpoolById")]
        public async Task<ActionResult<CarpoolDto>> GetCarpoolByID(int CarpoolId)
        {
            var result = carpoolBusinessService.GetCarpoolByID(CarpoolId);

            if (result == null)
            {
                return StatusCode(404, "CarpoolID not found.");
            }
            return result;
        }

        /// <summary>
        /// Function to delete all carpools
        /// </summary>
        /// <returns></returns>
        /// <response code="204">Successfully Deleted all Carpools>
        /// <response code="400">If the item is null</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("/deleteAllCarpools")]
        public async Task<ActionResult<CarpoolS>> Delete()
        {
            carpoolBusinessService.DeleteAllCarpools();
            return StatusCode(200, "successfully deleted all Carpools");
        }

        /// <summary>
        /// Delete a Carpool by ID given by the User
        /// </summary>
        /// <param name="CarpoolID"></param>
        /// <returns></returns>
        /// <response code="200">Successfully Deleted chosen carpool with ID chosen by user>
        /// <response code="204">If the item is null</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("/deleteCarpoolByID")]
        public async Task<ActionResult<CarpoolDto>> DeleteByID(int CarpoolID)
        {
            var result = carpoolBusinessService.DeleteCarpoolbyID(CarpoolID);
            if (result == null)
            {
                return StatusCode(404, "CarpoolID not found");
            }
            return result;
        }

        /// <summary>
        /// Edit the carpool by ID given by the User
        /// </summary>
        /// <param name="CarpoolID"></param>
        /// <param name="FreeSeats"></param>
        /// <param name="NewDriver"></param>
        /// <returns></returns>
        /// <response code="200">Successfully edited the carpool matching the ID chosen by the User>
        /// <response code="400">If the item is null</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/EditCarpoolByID")]
        public async Task<ActionResult<CarpoolDto>> EditCarpoolByID(int CarpoolID, int FreeSeats, string NewDriver)
        {
            var result = carpoolBusinessService.EditCarpoolByID(CarpoolID, FreeSeats, NewDriver);
            if (result == null)
            {
                return StatusCode(404, "CarpoolID not found.");
            }
            return result;
        }


    }
}
