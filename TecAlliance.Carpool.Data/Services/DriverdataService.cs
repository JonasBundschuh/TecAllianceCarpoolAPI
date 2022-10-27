using System.Reflection;
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
            var DriverCount = File.ReadAllLines(DriverPath()).Count() + 1;

            //Create Variable that contains all contents for the Driver Data
            string newDriverDataSet = $"{DriverCount};{driver.FreeSeats};{driver.Smoke};{driver.FullName};{driver.StartLoc};{driver.EndLoc};{driver.TimeStart};{driver.TimeEnd}\n";

            //Write dataset in Driver csv file
            File.AppendAllText(DriverPath(), newDriverDataSet);
        }


        //DELETE ALL
        public void DeleteALlDrivers()
        {
            File.Delete(DriverPath());
        }

        //List of all drivers returning "driver"
        public List<Driver> AllDrivers()
        {
            CheckForDriverOrCreateFile();
            var readText = File.ReadAllLines(DriverPath());
            List<Driver> drivers = new List<Driver>();
            foreach (var line in readText)
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


        #region HelperMethods

        //Check if Driver file exists, if not create one
        public void CheckForDriverOrCreateFile()
        {
            if (!File.Exists(DriverPath()))
            {
                using (FileStream fs = File.Create(DriverPath()))
                {
                    File.Create(DriverPath());
                }

            }
            
        }

        //Dynamic path for Driver.csv
        public string DriverPath()
        {
            var originalpath = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(originalpath);
            string FinalPath = Path.Combine(path, @"..\..\..\..\..\", "TecAlliance.Carpool.Api\\TecAlliance.Carpool.Data\\CSV-Files\\Driver.csv");
            return FinalPath.ToString();
        }

        #endregion
    }
}