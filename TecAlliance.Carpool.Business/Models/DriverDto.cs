using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Business.Models
{
    public class DriverDto
    {

        //Create DriverDto Properties
        public string FreeSeats { get; set; }
        public string Smoke { get; set; }
        public string FullName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        //Constructor for DriverDto Properties
        public DriverDto(string freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            FreeSeats = freeSeats;
            Smoke = smoke;
            FullName = fullName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }

        public void AddNewDriver()
        {

        }
    }
}
