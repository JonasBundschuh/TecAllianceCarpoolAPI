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
