using System.Reflection;
using TecAlliance.Carpool.Data.Models;


namespace TecAlliance.Carpool.Data.Services
{
    public class DriverdataService
    {
        public string DriverPath()
        {
            var originalpath = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(originalpath);
            string FinalPath = Path.Combine(path, @"..\..\..\..\..\", "TecAlliance.Carpool.Api\\TecAlliance.Carpool.Data\\CSV-Files");
            return FinalPath.ToString();
        }
        //Add a new Driver (line) to Driver csv
        public void AddNewDriver(Driver driver)
        {
            //Check if Driver file exists, if not create one
            CheckForDriverOrCreateFile();

            //Get amount of lines + Count up (The amount of lines is used as ID)
            var DriverCount = File.ReadAllLines($"{DriverPath()}\\Driver.csv").Count() + 1;

            //Create Variable that contains all contents for the Driver Data
            string newDriverDataSet = $"{DriverCount};{driver.FreeSeats};{driver.Smoke};{driver.FullName};{driver.StartLoc};{driver.EndLoc};{driver.TimeStart};{driver.TimeEnd}\n";

            //Write dataset in Driver csv file
            File.AppendAllText($"{DriverPath()}\\Driver.csv", newDriverDataSet);
        }


        public List<Driver> AllDrivers()
        {
            var readText = File.ReadAllLines($"{DriverPath()}\\Driver.csv");
            List<Driver> drivers = new List<Driver>();
            foreach(var line in readText)
            {
                string[] splittedDrivers = line.Split(';');
                var foo = new Driver
                    (
                        splittedDrivers[0],
                        splittedDrivers[1],
                        splittedDrivers[2],
                        splittedDrivers[3],
                        splittedDrivers[4],
                        splittedDrivers[5],
                        splittedDrivers[6]
                    );
                drivers.Add(foo);
            }
            return drivers;
        }

        //Check if Driver file exists, if not create one
        public void CheckForDriverOrCreateFile()
        {
            if (File.Exists($"{DriverPath()}\\Driver.csv"))
            {

            }
            else
            {
                File.Create($"{DriverPath()}\\Driver.csv");
            }
        }
    }
}