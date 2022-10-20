using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

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
            return StatusCode(200,"successfully added new Carpool");
        }

        //Get all Carpools
        [HttpGet]
        [Route("/getCarpool")]
        public async Task<ActionResult<List<CarpoolDto>>> Get()
        {
            var CarpoolToGive = carpoolBusinessService.FinalCarpoolList();
            return CarpoolToGive;
        }
    }
}
