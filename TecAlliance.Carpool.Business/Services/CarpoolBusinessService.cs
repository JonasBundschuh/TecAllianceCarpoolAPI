using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class CarpoolBusinessService
    {
        CarpoolDataService carpoolDataService = new CarpoolDataService();

        public CarpoolS AddCarpool(CarpoolDto carpoolDto)
        {         
            var carpool = ConvertCarpoolDtoToCarpools(carpoolDto);
            var AddSomeNewCarpool= new CarpoolDataService();
            AddSomeNewCarpool.AddNewCarpool(carpool);
            return carpool;
        }

        public CarpoolS ConvertCarpoolDtoToCarpools(CarpoolDto carpoolDto)
        {
            var convertedCarpool = new CarpoolS(carpoolDto.FreeSeats, carpoolDto.DriverName, carpoolDto.StartLoc, carpoolDto.EndLoc, carpoolDto.TimeStart, carpoolDto.TimeEnd);
            return convertedCarpool;
        }

        public List<CarpoolDto> FinalCarpoolList()
        {
            var foo = new CarpoolDataService();
            List<CarpoolDto> Proplist = new List<CarpoolDto>();
            List<CarpoolS> listS = new List<CarpoolS>();
            foreach (CarpoolS Cars in listS)
            {
                var sdto = ConvertCarpool(Cars);
                Proplist.Add(sdto);
            }
            return Proplist;
        }

        public CarpoolDto ConvertCarpool(CarpoolS Proplist)
        {
            var AppendCarPool = new CarpoolDto(Proplist.FreeSeats, Proplist.DriverName, Proplist.StartLoc, Proplist.EndLoc, Proplist.TimeDepart, Proplist.TimeArrive);
            return AppendCarPool;
        }
    }
}
