using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;

namespace T_ecAllianceCarpoolAPI.Controllers
{
    [ApiController]
    [Route("[controller/carpools]")]
    public class CarpoolController
    {
        private CarpoolBusinessService carpoolBusinessService;
        private readonly ILogger<CarpoolController> logger;
        public CarpoolController(ILogger <CarpoolController> logger)
        {
            carpoolBusinessService = new CarpoolBusinessService();            
        }

        [HttpPost]
        public async Task<ActionResult<CarpoolDto>> Post(CarpoolDto carpool)
        {
            carpoolBusinessService.AddCarpool(carpool);
            return NoContent();
        }
    }
}
