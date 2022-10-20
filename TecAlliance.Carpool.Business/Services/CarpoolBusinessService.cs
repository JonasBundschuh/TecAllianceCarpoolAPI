using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class CarpoolBusinessService
    {

        // Create a new CarpoolDataService
        CarpoolDataService carpoolDataService = new CarpoolDataService();


        //Add a new Carpool
        public CarpoolS AddCarpool(CarpoolDto carpoolDto)
        {
            var carpool = ConvertCarpoolDtoToCarpools(carpoolDto);
            var AddSomeNewCarpool = new CarpoolDataService();
            AddSomeNewCarpool.AddNewCarpool(carpool);
            return carpool;
        }


        //Convert CarpoolDto to "convertedCarpool" to use in "carpool"
        public CarpoolS ConvertCarpoolDtoToCarpools(CarpoolDto carpoolDto)
        {
            var convertedCarpool = new CarpoolS(carpoolDto.FreeSeats, carpoolDto.DriverName, carpoolDto.StartLoc, carpoolDto.EndLoc, carpoolDto.TimeStart, carpoolDto.TimeEnd);
            return convertedCarpool;
        }

        //Final List of carpools
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

        //Another conveerter
        public CarpoolDto ConvertCarpool(CarpoolS Proplist)
        {
            var AppendCarPool = new CarpoolDto(Proplist.FreeSeats, Proplist.DriverName, Proplist.StartLoc, Proplist.EndLoc, Proplist.TimeDepart, Proplist.TimeArrive);
            return AppendCarPool;
        }

        public void DeleteAllCarpools()
        {
            File.Delete("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpools.csv");
        }
    }
}
