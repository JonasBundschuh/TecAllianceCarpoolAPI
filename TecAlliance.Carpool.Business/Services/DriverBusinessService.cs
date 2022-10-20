using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    {

        //Create new DriverdataService
        DriverdataService driverDataSercice = new DriverdataService();

        //Add a new Driver
        public void AddDriver(DriverDto driverDto)
        {
            var driver = ConvertDriverDtoToDriver(driverDto);
            var AddSomeNewDriver = new DriverdataService();
            AddSomeNewDriver.AddNewDriver(driver);
        }

        //Method to convert DriverDto to "convertedDriver" to use for "driver"
        public Driver ConvertDriverDtoToDriver(DriverDto driverDto)
        {
            var convertedDriver = new Driver(driverDto.FreeSeats, driverDto.Smoke, driverDto.FullName, driverDto.StartLoc, driverDto.EndLoc, driverDto.TimeStart, driverDto.TimeEnd);
            return convertedDriver;
        }

        public void DeleteAllDrivers(Driver driver)
        {
            File.Delete("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
        }
    }
}
