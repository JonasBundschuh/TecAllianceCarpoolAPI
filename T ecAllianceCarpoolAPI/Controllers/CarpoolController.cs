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

        //Post Carpool
        [HttpPost]
        [Route("/postCarpool")]
        public async Task<ActionResult<CarpoolS>> Post(CarpoolDto carpool)
        {
            carpoolBusinessService.AddCarpool(carpool);
            return StatusCode(200, "successfully added new Carpool");
        }

        //Get all Carpools
        [HttpGet]
        [Route("/getAllCarpools")]
        public async Task<ActionResult<List<CarpoolDto>>> Get()
        {
            return carpoolBusinessService.GetAllCarpools();
        }

        [HttpDelete]
        [Route("/getCarpoolById")]

        //Delete all Carpools
        [HttpDelete]
        [Route("/deleteAllCarpools")]
        public async Task<ActionResult<CarpoolS>> Delete()
        {
            carpoolBusinessService.DeleteAllCarpools();
            return StatusCode(200, "successfully deleted all Carpools");
        }

        [HttpDelete]
        [Route("/deleteCarpoolByID{CarpoolID}")]
        public async Task<ActionResult<CarpoolDto>> DeleteByID(int CarpoolID)
        {
            var result = carpoolBusinessService.DeleteCarpoolbyID(CarpoolID);
            if ( result == null)
            {
                return StatusCode(404, "CarpoolID not found");
            }
            return result;
        }        
    }
}
