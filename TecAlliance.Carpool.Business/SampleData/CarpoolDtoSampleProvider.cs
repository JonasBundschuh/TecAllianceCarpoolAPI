using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;
using TecAlliance.Carpool.Business.Models;

namespace TecAlliance.Carpool.Business.SampleData
{
    public class CarpoolDtoSampleProvider : IExamplesProvider<CarpoolDto>
    {
        public CarpoolDto GetExamples()
        {
            return new CarpoolDto
            {
                FreeSeats = 4,
                DriverName = "Max Mustermann",
                StartLoc = "Lauda-Königshofen",
                EndLoc = "Weikersheim",
                TimeStart = "06:00",
                TimeEnd = "08:00"
            };
        }
    }
}
