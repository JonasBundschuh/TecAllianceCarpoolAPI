using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class CarpoolBusinessService
    {
        //Create a new CarpoolDataService
        CarpoolDataService carpoolDataService = new CarpoolDataService();


        //- - - - - - Main METHODS - - - - - - 



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

        //DELETE all
        //Delete the Carpool file
        public void DeleteAllCarpools()
        {
            carpoolDataService.DeleteAllCarpools();
        }

        //DELETE By Id
        //Method to delete Carpool by its ID
        public CarpoolDto? DeleteCarpoolbyID(int CarpoolId)
        {
            //Go thru all strings in Carpool File
            var currentList = carpoolDataService.AllCarpools();
            //Create List for later, Has the same content from Carpool file but without the deleted one
            List<CarpoolS> UpdatedList = new List<CarpoolS>();
            //Create a new (empty) CarpoolDto
            var DeletedCarpool = new CarpoolDto() { };

            //for each carPoolDataSet (carPoolS) in currentList (Carpool file) do:
            foreach (CarpoolS carPoolDataSet in currentList)
            {
                //if the Carpool ID the user entered doesn'tmatches a ID in Carpool file do:
                if (!(CarpoolId == Convert.ToInt32(carPoolDataSet.Id)))
                {
                    //Add updated content to Updated List
                    UpdatedList.Add(carPoolDataSet);
                }
                else
                {
                    //Give each prop their place
                    DeletedCarpool.FreeSeats = Convert.ToInt32(carPoolDataSet.FreeSeats);
                    DeletedCarpool.DriverName = carPoolDataSet.DriverName;
                    DeletedCarpool.StartLoc = carPoolDataSet.StartLoc;
                    DeletedCarpool.EndLoc = carPoolDataSet.EndLoc;
                    DeletedCarpool.TimeStart = carPoolDataSet.TimeDepart;
                    DeletedCarpool.TimeEnd = carPoolDataSet.TimeArrive;
                }
            }
            if (UpdatedList.Count() == currentList.Count())
            {
                return null;
            }

            //Rewrite the Carpool Csv
            foreach (var newCarPoolItem in UpdatedList)
            {
                carpoolDataService.AddNewCarpool(newCarPoolItem);
            }
            return DeletedCarpool;
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
                if (CarpoolID == Convert.ToInt32(carpool.Id))
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





        //- - - - - - HELPER METHODS - - - - - - 


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