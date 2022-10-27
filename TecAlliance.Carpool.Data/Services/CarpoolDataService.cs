using System.Reflection;
using System.Text;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataService
    {
        #region Main Methods


        // CREATE
        //Method to add a new carpool 
        public void AddNewCarpool(CarpoolS carpool)
        {
            //Check If carpools file exists, if not create it
            CheckForOrCreateCarpoolFile();

            //check how many lines are there and then set the ID
            int Id = File.ReadLines(CarpoolPath()).Count() + 1;

            //Create  variable for Carpool Driver data set
            string newCarPoolDataSet = $"{Id};{carpool.FreeSeats};{carpool.DriverName};{carpool.StartLoc};{carpool.EndLoc};{carpool.TimeDepart};{carpool.TimeArrive}\n";

            //write dataset in Carpools file
            File.AppendAllText(CarpoolPath(), newCarPoolDataSet);
        }



        public void DeleteSpecificCarpool(int Id)
        {
            CheckForOrCreateCarpoolFile();
            int IdOfCarpool = Id;
            var readText = File.ReadAllLines(CarpoolPath(), Encoding.UTF8);
            List<string> readList = ReadCarPoolList(CarpoolPath());
            var MatchingCarPool = readList.FirstOrDefault(x => x.Split(';')[0] == IdOfCarpool.ToString());
            List<string> carPool = readList.Where(x => x.Split(';')[0] != IdOfCarpool.ToString()).ToList();
            carPool.Add(MatchingCarPool);
            carPool.Remove(MatchingCarPool);
            var orderdCarpool = carPool.OrderBy(x => x.Split(';')[0]);
            File.Delete(CarpoolPath());
            File.AppendAllLines(CarpoolPath(), orderdCarpool);
        }



        public List<string> ReadCarPoolList(string path)
        {
            var CarPoolList = File.ReadAllLines(path, Encoding.UTF8);
            List<string> readList = CarPoolList.ToList();
            return readList;
        }


        //GET All
        //List of all Carpools
        public List<CarpoolS> AllCarpools()
        {
            // Check for the CarPool file or create it if it doesnt exist yet
            CheckForOrCreateCarpoolFile();
            //Read all lines in Carpool.csv
            var readText = File.ReadAllLines(CarpoolPath());
            //Create a new CarpoolS Lost
            List<CarpoolS> carpools = new List<CarpoolS>();
            //go thru every line and fill & Split properties in the created List
            foreach (var carpool in readText)
            {

                string[] splittedCarpools = carpool.Split(';');
                var foo = new CarpoolS(

                        Convert.ToInt32(splittedCarpools[0]),
                        splittedCarpools[1],
                        splittedCarpools[2],
                        splittedCarpools[3],
                        splittedCarpools[4],
                        splittedCarpools[5],
                        splittedCarpools[6]
                    );
                carpools.Add(foo);
            }
            return carpools;
        }

        //DELETE All
        //delete Carpool file
        public void DeleteAllCarpools()
        {
            //Delete the Carpool.csv file
            File.Delete(CarpoolPath());
        }

        #endregion Main Methods 

        #region Helper Methods

        //Checks if Carpoolfile exists, if not create one
        public void CheckForOrCreateCarpoolFile()
        {
            if (!File.Exists(CarpoolPath()))
            {
                using (FileStream fs = File.Create(CarpoolPath()))
                {
                    File.Create(CarpoolPath());
                }
            }
        }

        //Get the Carpool file path dynamically
        public string CarpoolPath()
        {
            var originalpath = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(originalpath);
            string FinalPath = Path.Combine(path, @"..\..\..\..\", "TecAlliance.Carpool.Data\\CSV-Files\\Carpool.csv");
            return FinalPath.ToString();
        }
        #endregion
    }
}