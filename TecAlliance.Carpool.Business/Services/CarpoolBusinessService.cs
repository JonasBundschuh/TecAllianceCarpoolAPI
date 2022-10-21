using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;
using System.IO;

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

        //Put all capools in a List
        public List <CarpoolDto> GetAllCarpools()
        {
            CheckForCarpoolFile();
            List<CarpoolS> everyCarpool= carpoolDataService.AllCarpools();            
            List<CarpoolDto> AllCarpools = new List<CarpoolDto>();
            foreach(CarpoolS line in everyCarpool)
            {
                CarpoolDto carpoolDto = ConvertCarpoolsList(line);
                AllCarpools.Add(carpoolDto);
            }
            return AllCarpools;
        }

        //Convert CarpoolS to CarpoolDto
        public CarpoolDto ConvertCarpoolsList(CarpoolS carpoolS)
        {
            var convertedCarpoolsList = new CarpoolDto(carpoolS.FreeSeats, carpoolS.DriverName, carpoolS.StartLoc, carpoolS.EndLoc, carpoolS.TimeDepart, carpoolS.TimeDepart);
            return convertedCarpoolsList;
        }

        //Checks if Carpools file Exists, if not create one
        public void CheckForCarpoolFile()
        {
            CheckForCarpoolFileLoop:
            if (File.Exists("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv"))
            {

            }
            else
            {
                File.Create("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv");
                goto CheckForCarpoolFileLoop;
            }
            
            
        }

        //method to delete Carpool file
        public void DeleteAllCarpools()
        {
            File.Delete("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv");
        }
    }
}
