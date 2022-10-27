using System.Reflection;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    {

        //Create new DriverdataService
        DriverdataService driverDataSercice = new DriverdataService();


        //[x]
        //POST
        //Add a new driver
        public Driver AddDriver(DriverDto driverDto)
        {
            var driver = ConvertDriverDtoToDriver(driverDto);
            driverDataSercice.AddNewDriver(driver);
            return driver;

        }


        //[x]
        //GET ALL
        //Methods that gets ALL DRIVERS and RETURNS them in a LIST
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

        //[x]
        //DLELETE ALL DRIVERS
        //Deletes all drivers by deleting the whole Driver.csv file
        public void DeleteAllDrivers()
        {
            driverDataSercice.DeleteALlDrivers();
        }


        //[x]
        //DELETE BY ID
        //Method to delete a driver by the ID chosen by the User
        public void DeleteDriverbyID(int Id)
        {
            driverDataSercice.DeleteDriverById(Id);
        }


        //[x]
        //GET BY ID
        //Method to get/display a single driver by its ID (chosen by the user)
        public DriverDto? GetDriverByID(int DriverId)
        {
            DriverDto ChosenDriver = new DriverDto();
            var AllDrivers = driverDataSercice.AllDrivers();

            foreach (Driver driver in AllDrivers)
            {
                if (DriverId == driver.Id)
                {
                    ChosenDriver.FreeSeats = Convert.ToInt32(driver.FreeSeats);
                    ChosenDriver.Smoke = driver.Smoke;
                    ChosenDriver.FullName = driver.FullName;
                    ChosenDriver.StartLoc = driver.StartLoc;
                    ChosenDriver.EndLoc = driver.EndLoc;
                    ChosenDriver.TimeStart = driver.TimeStart;
                    ChosenDriver.TimeEnd = driver.TimeEnd;
                }
            }
            if (String.IsNullOrEmpty(ChosenDriver.FullName))
            {
                return null;
            }
            return ChosenDriver;
        }



        //[x]
        //UPDATE
        //Method to edit a existing Driver by the ID entered by the User
        public DriverDto? EditDriverByID(int DriverID, string newDriverName, string NowSmoker)
        {
            DriverDto chosenDriver = new DriverDto();
            var Alldrivers = driverDataSercice.AllDrivers();

            List<Driver> UpdatedList = new List<Driver>();

            foreach (Driver driver in Alldrivers)
            {
                if (DriverID == driver.Id)
                {
                    chosenDriver.FreeSeats = driver.FreeSeats;
                    chosenDriver.Smoke = driver.Smoke;
                    chosenDriver.FullName = driver.FullName;
                    chosenDriver.StartLoc = driver.StartLoc;
                    chosenDriver.EndLoc = driver.EndLoc;
                    chosenDriver.TimeStart = driver.TimeStart;
                    chosenDriver.TimeEnd = driver.TimeEnd;

                    driver.Smoke = NowSmoker;
                    driver.FullName = newDriverName;

                    UpdatedList.Add(ConvertDriverDtoToDriver(chosenDriver));
                }
                else
                {
                    UpdatedList.Add(driver);
                }
            }
            foreach (var newEntry in UpdatedList)
            {
                driverDataSercice.AddNewDriver(newEntry);
            }
            if (String.IsNullOrEmpty(chosenDriver.EndLoc))
            {
                return null;
            }

            return chosenDriver;
        }



        #region HelperMethods

        //Checks if Driver.csv exists
        public void CheckIfDriverFileExist()
        {
            FileStream fs = File.Create(DriverPath());
            if (File.Exists(DriverPath()))
            {

            }
            else
            {
                File.Create(DriverPath());
            }
        }


        //Method for dynamic path of Driver File exists
        public string DriverPath()
        {
            var originalpath = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(originalpath);
            string FinalPath = Path.Combine(path, @"..\..\..\..\..\", "TecAlliance.Carpool.Api\\TecAlliance.Carpool.Data\\CSV-Files\\Driver.csv");
            return FinalPath.ToString();
        }


        //Method to Convert DriverDto to driver
        public Driver ConvertDriverDtoToDriver(DriverDto driverDto)
        {
            var convertedDriver = new Driver(driverDto.FreeSeats, driverDto.Smoke, driverDto.FullName, driverDto.StartLoc, driverDto.EndLoc, driverDto.TimeStart, driverDto.TimeEnd);
            return convertedDriver;
        }

        //Method to convert Driver List
        public DriverDto ConvertDriverList(Driver driver)
        {
            var convertedDriverList = new DriverDto(driver.FreeSeats, driver.Smoke, driver.FullName, driver.StartLoc, driver.EndLoc, driver.TimeStart, driver.TimeEnd);
            return convertedDriverList;
        }
        #endregion
    }
}
