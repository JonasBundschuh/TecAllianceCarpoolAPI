using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    {
        DriverdataService driverDataSercice = new DriverdataService();
        public void AddDriver(DriverDto driverDto)
        {
            var driver = ConvertDriverDtoToDriver(driverDto);
            var AddSomeNewDriver = new DriverdataService();
            AddSomeNewDriver.AddNewDriver(driver);
        }
        public Driver ConvertDriverDtoToDriver(DriverDto driverDto)
        {            
            var convertedDriver = new Driver(driverDto.FreeSeats, driverDto.Smoke, driverDto.FullName, driverDto.StartLoc, driverDto.EndLoc, driverDto.TimeStart, driverDto.TimeEnd);
            return convertedDriver;           
        }
    }
}
