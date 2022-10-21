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
            CheckIfDriverFikeExist();
            List<Driver> everyDriver = driverDataSercice.AllDrivers();
            List<DriverDto> AllDrivers = new List<DriverDto>();
            foreach(Driver line in everyDriver)
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

        public void CheckIfDriverFikeExist()
        {
            if (File.Exists("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv"))
            {

            }
            else
            {
                File.Create("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
            }
        }
    }
}
