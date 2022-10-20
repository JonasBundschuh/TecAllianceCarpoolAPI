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

        public void GetAllCarpools()
        {

            foreach(string line in File.ReadLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool"))
            {
                
            }
        }
        public void DeleteAllCarpools()
        {
            File.Delete("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpools.csv");
        }
    }
}
