using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class DriverdataService
    {

        //Add a new Driver (line) to Driver csv
        public void AddNewDriver(Driver driver)
        {
            //Check if Driver file exists, if not create one
            CheckForDriverOrCreateFile();

            //Get amount of lines + Count up (The amount of lines is used as ID)
            var DriverCount = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv").Count() + 1;

            //Create Variable that contains all contents for the Driver Data
            string newDriverDataSet = $"{DriverCount};{driver.FreeSeats};{driver.Smoke};{driver.FullName};{driver.StartLoc};{driver.EndLoc};{driver.TimeStart};{driver.TimeEnd}\n";

            //Write dataset in Driver csv file
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Drivers\\Driver.csv", newDriverDataSet);
        }


        //Check if Driver file exists, if not create one
        public void CheckForDriverOrCreateFile()
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