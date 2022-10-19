using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using TecAlliance.Carpool.Data.Models;
using System.IO;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataService
    {
        int CarpoolID = 0;
        public void AddNewCarpool(string freeSeats, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            foreach (string file in Directory.EnumerateFiles("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers", "*.csv"))
            {
                CarpoolID++;
            }
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Driver{CarpoolID}.csv", $"{CarpoolID};{freeSeats};{fullName};{startLoc};{endLoc};{timeStart};{timeEnd};\n");


        }
    }
}
