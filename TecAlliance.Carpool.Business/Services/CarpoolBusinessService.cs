using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class CarpoolBusinessService
    {
        CarpoolDataService carpoolDataService = new CarpoolDataService();

        public void AddCarpool(CarpoolDto carpoolDto)
        {
            var carpool = ConvertCarpoolDtoToCarpools(carpoolDto);
        }

        public CarpoolS ConvertCarpoolDtoToCarpools(CarpoolDto carpoolDto)
        {
            var convertedCarpool = new CarpoolS(carpoolDto.FreeSeats, carpoolDto.DriverName, carpoolDto.StartLoc, carpoolDto.EndLoc, carpoolDto.TimeStart, carpoolDto.TimeEnd)
                return convertedCarpool;
        }
    }
}
