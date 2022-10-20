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
            var FileCount = File.ReadLines("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpools.csv").Count() + 1;

            //Create  variable for Carpool Driver data set
            string newCarPoolDataSet = $"{FileCount};{carpool.FreeSeats};{carpool.DriverName};{carpool.StartLoc};{carpool.EndLoc};{carpool.TimeDepart};{carpool.TimeArrive}\n";

            //write dataset in Carpools file
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpools.csv", newCarPoolDataSet);
        }

        //Method to check if Carpools file exists, if not create one
        public void CheckForOrCreateCarpoolFile()
        {
            if (File.Exists("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpools.csv"))
            {

            }
            else
            {
                File.Create("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Carpools.csv");
            }
        }

    }
}
