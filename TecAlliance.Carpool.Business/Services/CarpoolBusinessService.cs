using TecAlliance.Carpool.Business.Interfaces;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Interfaces;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class CarpoolBusinessService : ICarpoolBusinessService
    {

        ICarpoolDataService carpoolDataService;


        public CarpoolBusinessService(ICarpoolDataService xarpoolDataService)
        {
            carpoolDataService = xarpoolDataService;
        }

        #region Main Methods


        // CREATE
        //Add a new Carpool
        public CarpoolS AddCarpool(CarpoolDto carpoolDto)
        {
            var carpool = ConvertCarpoolDtoToCarpools(carpoolDto);
            carpoolDataService.AddNewCarpool(carpool);
            return carpool;

        }


        //GET All
        //returns all capools in a List
        public List<CarpoolDto> GetAllCarpools()
        {
            List<CarpoolS> everyCarpool = carpoolDataService.AllCarpools();
            List<CarpoolDto> AllCarpools = new List<CarpoolDto>();
            foreach (CarpoolS line in everyCarpool)
            {
                CarpoolDto carpoolDto = ConvertCarpoolsList(line);
                AllCarpools.Add(carpoolDto);
            }
            return AllCarpools;
        }


        //DELETE ALL
        //Delete the Carpool file
        public void DeleteAllCarpools()
        {
            carpoolDataService.DeleteAllCarpools();
        }


        //DELETE BY ID
        //Delete the Carpool matching the Id chosen by the user
        public void DeleteCarpoolbyId(int Id)
        {
            carpoolDataService.DeleteSpecificCarpool(Id);
        }
         

        //GET By Id
        //Method to get any carpool by a ID entered by the user
        public CarpoolDto? GetCarpoolByID(int CarpoolId)
        {
            CarpoolDto ChosenCarpool = new CarpoolDto();
            var AllCarpools = carpoolDataService.AllCarpools();

            foreach (CarpoolS carpool in AllCarpools)
            {
                if (CarpoolId == carpool.Id)
                {
                    ChosenCarpool.FreeSeats = Convert.ToInt32(carpool.FreeSeats);
                    ChosenCarpool.DriverName = carpool.DriverName;
                    ChosenCarpool.StartLoc = carpool.StartLoc;
                    ChosenCarpool.EndLoc = carpool.EndLoc;
                    ChosenCarpool.TimeStart = carpool.TimeDepart;
                    ChosenCarpool.TimeEnd = carpool.TimeArrive;
                }
            }
            if (String.IsNullOrEmpty(ChosenCarpool.DriverName))
            {
                return null;
            }
            return ChosenCarpool;
        }


        //UPDATE
        //Method to edit a existing carpool by the ID entered by the User
        public CarpoolDto? EditCarpoolByID(int CarpoolID, int FreeSeats, string NewDriver)
        {

            CarpoolDto chosenCarpool = new CarpoolDto();
            var allCarPools = carpoolDataService.AllCarpools();

            List<CarpoolS> updatedList = new List<CarpoolS>();

            foreach (CarpoolS carpool in allCarPools)
            {
                if (CarpoolID == Convert.ToInt32(carpoolDataService.GetId()))
                {
                    chosenCarpool.FreeSeats = Convert.ToInt32(FreeSeats);
                    chosenCarpool.DriverName = NewDriver;
                    chosenCarpool.StartLoc = carpool.StartLoc;
                    chosenCarpool.EndLoc = carpool.EndLoc;
                    chosenCarpool.TimeStart = carpool.TimeDepart;
                    chosenCarpool.TimeEnd = carpool.TimeArrive;

                    updatedList.Add(ConvertCarpoolDtoToCarpools(chosenCarpool));
                }
                else
                {
                    updatedList.Add(carpool);
                }
            }
            foreach (var newEntry in updatedList)
            {
                carpoolDataService.AddNewCarpool(newEntry);
            }
            if (String.IsNullOrEmpty(chosenCarpool.DriverName))
            {
                return null;
            }
            return chosenCarpool;
        }

        #endregion Main Methods



        #region Helper Methods


        //Convert CarpoolS to CarpoolDto
        public CarpoolDto ConvertCarpoolsList(CarpoolS carpoolS)
        {
            var convertedCarpoolsList = new CarpoolDto(Convert.ToInt32(carpoolS.FreeSeats), carpoolS.DriverName, carpoolS.StartLoc, carpoolS.EndLoc, carpoolS.TimeDepart, carpoolS.TimeDepart);
            return convertedCarpoolsList;
        }


        //Convert CarpoolDto to "convertedCarpool" to use in "carpool"
        public CarpoolS ConvertCarpoolDtoToCarpools(CarpoolDto carpoolDto)
        {
            var convertedCarpool = new CarpoolS(Convert.ToString(carpoolDto.FreeSeats), carpoolDto.DriverName, carpoolDto.StartLoc, carpoolDto.EndLoc, carpoolDto.TimeStart, carpoolDto.TimeEnd);
            return convertedCarpool;
        }
        
        #endregion
    }
}