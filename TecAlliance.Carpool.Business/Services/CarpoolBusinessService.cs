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

        //Put all capools in a List
        public List<CarpoolDto> GetAllCarpools()
        {
            CheckForCarpoolFile();
            List<CarpoolS> everyCarpool = carpoolDataService.AllCarpools();
            List<CarpoolDto> AllCarpools = new List<CarpoolDto>();
            foreach (CarpoolS line in everyCarpool)
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

        //Method to delete Carpool by its ID
        public CarpoolDto? DeleteCarpoolbyID(int CarpoolId)
        {
            //Go thru all strings in Carpool File
            var ReadAll = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv");
            //Create List for later, Has the same content from Carpool file but without the deleted one
            List<string> UpdatedList = new List<string>();
            //Create a new CarpoolDto
            var DeletedCarpool = new CarpoolDto() { };
            {

            };
            //for each line (string) in ReadAll (Carpool file) do:
            foreach (string line in ReadAll)
            {
                //Create new string array + split it at the ';'
                string[] AllCarpools = line.Split(';');
                //if the Carpool ID the user entered doesn'tmatches a ID in Carpool file do:
                if (!(CarpoolId == Convert.ToInt32(AllCarpools[0])))
                {
                    //Add updated content to Updated List
                    UpdatedList.Add(line);
                }
                else
                {
                    //Give each prop their place
                    DeletedCarpool.FreeSeats = AllCarpools[1];
                    DeletedCarpool.DriverName = AllCarpools[2];
                    DeletedCarpool.StartLoc = AllCarpools[3];
                    DeletedCarpool.EndLoc = AllCarpools[4];
                    DeletedCarpool.TimeStart = AllCarpools[5];
                    DeletedCarpool.TimeEnd = AllCarpools[6];
                }
            }
            if (UpdatedList.Count() == ReadAll.Count())
            {
                return null;
            }
            //Rewrite the Carpool Csv
            File.WriteAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv", UpdatedList);
            return DeletedCarpool;
        }

        public CarpoolDto? GetCarpoolByID(int CarpoolId)
        {
            CarpoolDto ChosenCarpool = new CarpoolDto();
            CheckForCarpoolFile();
            var AllCarpools = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv");
            foreach (string carpool in AllCarpools)
            {
                var splittedCarpool = carpool.Split(';');
                if (CarpoolId == Convert.ToInt32(splittedCarpool[0]))
                {
                    ChosenCarpool.FreeSeats = splittedCarpool[1];
                    ChosenCarpool.DriverName = splittedCarpool[2];
                    ChosenCarpool.StartLoc = splittedCarpool[3];
                    ChosenCarpool.EndLoc = splittedCarpool[4];
                    ChosenCarpool.TimeStart = splittedCarpool[5];
                    ChosenCarpool.TimeEnd = splittedCarpool[6];
                }
               
            }

            if (String.IsNullOrEmpty(ChosenCarpool.DriverName))
            {
                return null;
            }
            return ChosenCarpool;



        }
    }
}