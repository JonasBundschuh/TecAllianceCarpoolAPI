using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;
using static System.Formats.Asn1.AsnWriter;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    { 
        DriverdataService driverDataSercice = new DriverdataService();

        
        public void AddDriver(DriverDto driverDto)
        {

            var driver = ConvertDriverDtoToDriver(driverDto);
        }
        public Driver ConvertDriverDtoToDriver(DriverDto driverDto)
        {
            var convertedDriver = new Driver(driverDto.FreeSeats, driverDto.Smoke, driverDto.FullName, driverDto.StartLoc, driverDto.EndLoc, driverDto.TimeStart, driverDto.TimeEnd);
            
                return convertedDriver;
        }
        
    }
}
