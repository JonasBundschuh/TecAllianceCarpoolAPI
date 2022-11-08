using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Business.Interfaces
{
    public interface IDriverBusinessService
    {
        //Add a new Driber
        Driver AddDriver(DriverDto driverDto);

        //get every single driver at once
        List<DriverDto> GetAllDrivers();

        //get one specific driver chosen by the user (by ID)
        DriverDto? GetDriverByID(int DriverId);

        //delete every single driver
        void DeleteAllDrivers();

        //delete one specific driver chosen by the user (by ID)
        void DeleteDriverbyID(int Id);

        //edit a specific driver chosen by the user (by ID)
        DriverDto? EditDriverByID(int DriverID, string newDriverName, string NowSmoker);
    }
}
