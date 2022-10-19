using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class DriverdataService
    {
        int DriverID = 0;
        int CarpoolID = 0;



        public void AddNewDriver(Driver driver)
        {

            foreach (string file in Directory.EnumerateFiles("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers", "*.csv"))
            {
                DriverID++;
            }
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver{DriverID}.csv", $"{DriverID};{driver}\n");
        }

        List<string> AllDrivers = new List<string>();
        public void GetAllDrivers(Driver driver)
        {
            foreach (string file in Directory.EnumerateFiles("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers", "*.csv"))
            {
                AllDrivers.Add(file);
                foreach (string drivers in AllDrivers)
                {
                    string Drivers = drivers;
                }
            }


        }








    }
}
