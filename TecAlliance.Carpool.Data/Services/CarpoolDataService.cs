using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataService
    {
        //Method to add a new carpool
        public void AddNewCarpool(CarpoolS carpool)
        {
            //Check If carpools file exists, if not create it
            CheckForOrCreateCarpoolFile();

            //check how many lines are there and then set the ID
            var FileCount = File.ReadLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv").Count() + 1;

            //Create  variable for Carpool Driver data set
            string newCarPoolDataSet = $"{FileCount};{carpool.FreeSeats};{carpool.DriverName};{carpool.StartLoc};{carpool.EndLoc};{carpool.TimeDepart};{carpool.TimeArrive}\n";

            //write dataset in Carpools file
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv", newCarPoolDataSet);
        }


        //List of all Carpools
        public List<CarpoolS> AllCarpools()
        {
            //Read all lines in Carpool.csv
            var readText = File.ReadAllLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv");
            //Create a new CarpoolS Lost
            List<CarpoolS> carpools = new List<CarpoolS>();
            //go thru every line and fill & Split properties in the created List
            foreach(var carpool in readText)
            {
                
                string[] splittedCarpools = carpool.Split(';');
                var foo = new CarpoolS
                    (
                        splittedCarpools[0],
                        splittedCarpools[1],
                        splittedCarpools[2],
                        splittedCarpools[3],
                        splittedCarpools[4],
                        splittedCarpools[5]
                    );
                carpools.Add(foo);
            }
            return carpools;
        }

        //Checks if Carpoolfile exists, if not create one
        public void CheckForOrCreateCarpoolFile()
        {
            if (File.Exists("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv"))
            {

            }
            else
            {
                File.Create("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpool.csv");
            }
        }
    }
}
