using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    {

        //Create new DriverdataService
        DriverdataService driverDataSercice = new DriverdataService();

        //Add a new DriverSS
        public void AddDriver(DriverDto driverDto)
        {
            var driver = ConvertDriverDtoToDriver(driverDto);
            var AddSomeNewDriver = new DriverdataService();
            AddSomeNewDriver.AddNewDriver(driver);
        }

        public List<DriverDto> GetAllDrivers()
        {
            CheckIfDriverFileExist();
            List<Driver> everyDriver = driverDataSercice.AllDrivers();
            List<DriverDto> AllDrivers = new List<DriverDto>();
            foreach (Driver line in everyDriver)
            {
                DriverDto driverDto = ConvertDriverList(line);
                AllDrivers.Add(driverDto);
            }
            return AllDrivers;
        }

        public DriverDto ConvertDriverList(Driver driver)
        {
            var convertedDriverList = new DriverDto(driver.FreeSeats, driver.Smoke, driver.FullName, driver.StartLoc, driver.EndLoc, driver.TimeStart, driver.TimeEnd);
            return convertedDriverList;
        }
        //Method to convert DriverDto to "convertedDriver" to use for "driver"
        public Driver ConvertDriverDtoToDriver(DriverDto driverDto)
        {
            var convertedDriver = new Driver(driverDto.FreeSeats, driverDto.Smoke, driverDto.FullName, driverDto.StartLoc, driverDto.EndLoc, driverDto.TimeStart, driverDto.TimeEnd);
            return convertedDriver;
        }

        public void DeleteAllDrivers()
        {
            File.Delete("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
        }

        public void CheckIfDriverFileExist()
        {
            if (File.Exists("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv"))
            {

            }
            else
            {
                File.Create("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
            }
        }

        public DriverDto? DeleteDriverbyID(int DriverId)
        {
            var ReadAll = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
            List<string> UpdatedList = new List<string>();
            var DeletedDriver = new DriverDto() { };
            
            foreach (string line in ReadAll)
            {
                string[] AllDrivers = line.Split(';');
                if (!(DriverId == Convert.ToInt32(AllDrivers[0])))
                {
                    UpdatedList.Add(line);
                }
                else
                {
                    DeletedDriver.FreeSeats = AllDrivers[1];
                    DeletedDriver.Smoke = AllDrivers[2];
                    DeletedDriver.FullName = AllDrivers[3];
                    DeletedDriver.StartLoc = AllDrivers[4];
                    DeletedDriver.EndLoc = AllDrivers[5];
                    DeletedDriver.TimeStart = AllDrivers[6];
                    DeletedDriver.TimeEnd = AllDrivers[7];
                }
            }
            if (UpdatedList.Count() == ReadAll.Count())
            {
                return null;
            }
            File.WriteAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv", UpdatedList);
            return DeletedDriver;
        }

        public DriverDto? GetDriverByID(int DriverId)
        {
            //check if the Driver file exists
            CheckIfDriverFileExist();
            //read all strings (driver) in Driver file
            var AllDrivers = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
            //Create a new DriverDto
            DriverDto ChosenDriver = new DriverDto();
            
            //for each string (driver) in Driver file (AllDrivers) do:
            foreach (string driver in AllDrivers)
            {
                //split the string at ';'
                var splittedDriver = driver.Split(';'); 
                if (DriverId == Convert.ToInt32(splittedDriver[0]))
                {
                    ChosenDriver.FreeSeats = splittedDriver[1];
                    ChosenDriver.Smoke = splittedDriver[2];
                    ChosenDriver.FullName = splittedDriver[3];
                    ChosenDriver.StartLoc = splittedDriver[4];
                    ChosenDriver.EndLoc = splittedDriver[5];
                    ChosenDriver.TimeStart = splittedDriver[6];
                    ChosenDriver.TimeEnd = splittedDriver[7];
                }
            }

            //Alternative to check if the driver with the ID entered by the user even exists
            if (String.IsNullOrEmpty(ChosenDriver.FullName))
            {
                return null;
            }
            return ChosenDriver;
        }

        public DriverDto? EditDriverByID(int DriverID, string newDriverName, string NowSmoker)
        {
            DriverDto chosenDriver = new DriverDto();
            CheckIfDriverFileExist();
            var ReadAll = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
            List<string> UpdatedList = new List<string>();
            foreach(string driver in ReadAll)
            {
                var SplittedCarpool = driver.Split(';');
                if (DriverID == Convert.ToInt32(SplittedCarpool[0]))
                {
                    chosenDriver.FreeSeats = SplittedCarpool[1];
                    chosenDriver.Smoke = SplittedCarpool[2];
                    chosenDriver.FullName = SplittedCarpool[3];
                    chosenDriver.StartLoc = SplittedCarpool[4];
                    chosenDriver.EndLoc = SplittedCarpool[5];
                    chosenDriver.TimeStart = SplittedCarpool[6];
                    chosenDriver.TimeEnd = SplittedCarpool[7];

                    SplittedCarpool[2] = NowSmoker;
                    SplittedCarpool[3] = newDriverName;

                    UpdatedList.Add($"{SplittedCarpool[0]};{SplittedCarpool[1]};{SplittedCarpool[2]};{SplittedCarpool[3]};{SplittedCarpool[4]};{SplittedCarpool[5]};{SplittedCarpool[6]};{SplittedCarpool[7]};");
                }
                else
                {
                    UpdatedList.Add(driver);
                }
            }
            if (String.IsNullOrEmpty(chosenDriver.EndLoc))
            {
                return null;
            }
            File.WriteAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv", UpdatedList);
            return chosenDriver;
        }

        public void CheckForRightID(string[] AllDrivers, string line)
        {

        }


    }
}
