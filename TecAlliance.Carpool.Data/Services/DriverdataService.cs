using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class DriverdataService
    {
        int DriverID = 0;
        List<string> AllDrivers = new List<string>();

        public void AddNewDriver(Driver driver)
        {
            CheckForDriverFile();
            foreach (string file in File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv"))
            {
                DriverID++;
            }
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv", $"{DriverID};{driver.FreeSeats};{driver.Smoke};{driver.FullName};{driver.StartLoc};{driver.EndLoc};{driver.TimeStart};{driver.TimeEnd}\n");
        }        
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
        public void CheckForDriverFile()
        {
            if (File.Exists("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv"))
            {
                
            }
            else
            {
                File.Create("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv");
            }
        }
    }
}