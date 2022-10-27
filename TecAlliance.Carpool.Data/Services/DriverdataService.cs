using System.Reflection;
using System.Text;
using TecAlliance.Carpool.Data.Models;


namespace TecAlliance.Carpool.Data.Services
{

    public class DriverdataService
    {
        #region Main Methods

        //Add a new Driver (line) to Driver csv
        public void AddNewDriver(Driver driver)
        {
            //Check if Driver file exists, if not create one
            CheckForDriverOrCreateFile();

            //Get ID
            var DriverCount = File.ReadAllLines(DriverPath()).Count() + 1;

            //Create Variable that contains all contents for the Driver Data
            string newDriverDataSet = $"{DriverCount};{driver.FreeSeats};{driver.Smoke};{driver.FullName};{driver.StartLoc};{driver.EndLoc};{driver.TimeStart};{driver.TimeEnd}\n";

            //Write Driver.csv file with the Data
            File.AppendAllText(DriverPath(), newDriverDataSet);
        }

        //DELETE ALL
        public void DeleteALlDrivers()
        {
            //Delete the Driver.csv file
            File.Delete(DriverPath());
        }

        //List of all drivers returning "driver"
        public List<Driver> AllDrivers()
        {
            //Call the method to check / create the Driver.csv file
            CheckForDriverOrCreateFile();
            var readText = File.ReadAllLines(DriverPath());
            List<Driver> drivers = new List<Driver>();
            foreach (var line in readText)
            {
                string[] splittedDrivers = line.Split(';');
                var foo = new Driver
                    (
                        Convert.ToInt32(splittedDrivers[0]),
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


        //Method to Delete a driver matching the ID chosen by the User
        public void DeleteDriverById(int Id)
        {

            CheckForDriverOrCreateFile();
            int IdOfCarpool = Id;
            var readText = File.ReadAllLines(DriverPath(), Encoding.UTF8);
            List<string> readList = ReadDriverList(DriverPath());
            var MatchingCarPool = readList.FirstOrDefault(x => x.Split(';')[0] == IdOfCarpool.ToString());
            List<string> carPool = readList.Where(x => x.Split(';')[0] != IdOfCarpool.ToString()).ToList();
            carPool.Add(MatchingCarPool);
            carPool.Remove(MatchingCarPool);
            var orderdCarpool = carPool.OrderBy(x => x.Split(';')[0]);
            File.Delete(DriverPath());
            File.AppendAllLines(DriverPath(), orderdCarpool);
        }


        #endregion Main Methods

        #region HelperMethods

        public List<string> ReadDriverList(string path)
        {
            var CarPoolList = File.ReadAllLines(path, Encoding.UTF8);
            List<string> readList = CarPoolList.ToList();
            return readList;
        }
        //Check if Driver file exists, if not create one
        public void CheckForDriverOrCreateFile()
        {
            //if Driver.csv DOESN'T exist
            if (!File.Exists(DriverPath()))
            {
                //using so you dont have to close the Filestream
                using (FileStream fs = File.Create(DriverPath()))
                {
                    //create the Driver.csv file
                    File.Create(DriverPath());
                }

            }

        }

        //Dynamic path for Driver.csv
        public string DriverPath()
        {
            //get the full path of where the application is running
            var originalpath = Assembly.GetExecutingAssembly().Location;
            //Get rid of the File name by getting the Directory name
            string path = Path.GetDirectoryName(originalpath);
            //Set the new path by going back 4 directories then going to the location of the Driver.csv file
            string FinalPath = Path.Combine(path, @"..\..\..\..\", "TecAlliance.Carpool.Data\\CSV-Files\\Driver.csv");
            return FinalPath.ToString();
        }


        #endregion Helper Methods
    }
}