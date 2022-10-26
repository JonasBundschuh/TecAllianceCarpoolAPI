using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Business.Models;
using Swashbuckle.AspNetCore.Filters;

namespace TecAlliance.Carpool.Business.SampleData
{
    public class DriverDtoSampleData : IExamplesProvider<DriverDto>
    {
        public DriverDto GetExamples() 
        {

            return new DriverDto
            {
                FreeSeats = "4",
                Smoke = "No",
                FullName = "Max Mustermann",
                StartLoc = "Lauda-Königshofen",
                EndLoc = "Weikersheim",
                TimeStart = "06:30",
                TimeEnd = "08:00"
            };
        } 
    }
}
