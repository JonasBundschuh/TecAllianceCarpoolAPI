using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    {
        //public DriverBusinessService()
        //{
            DriverdataService  driverDataSercice = new DriverdataService();
        //}

        public void AddDriver(string FreeSeats, string Smoke, string FullName, string StartLoc, string EndLoc, string TimeStart, string TimeEnd)
        {
            driverDataSercice.AddNewDriver(FreeSeats, Smoke, FullName, StartLoc, EndLoc, TimeStart, TimeEnd);
        }
        
    }
}
