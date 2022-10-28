using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Interfaces
{
    public interface ICarpoolDataService
    {
        #region Main Methods


        // CREATE
        //Method to add a new carpool 
        public void AddNewCarpool(CarpoolS carpool)
        {
            int Id = 0;
            ////Check If carpools file exists, if not create it
            CheckForOrCreateCarpoolFile();

            //Call GetId method to generate / get the ID to give to the new carpool
            Id = GetId();
            //Create  variable for Carpool Driver data set
            string newCarPoolDataSet = $"{Id};{carpool.FreeSeats};{carpool.DriverName};{carpool.StartLoc};{carpool.EndLoc};{carpool.TimeDepart};{carpool.TimeArrive}\n";

            //write dataset in Carpools file
            File.AppendAllText(CarpoolPath(), newCarPoolDataSet);
        }


        //DELETE BY ID
        //Method to delete a single carpool with matching ID to the ID chosen by the User
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


        //GET All
        //List of all Carpools
        public List<CarpoolS> AllCarpools()
        {
            CheckForOrCreateCarpoolFile();
            var readText = File.ReadAllLines(CarpoolPath());
            List<CarpoolS> carpools = new List<CarpoolS>();
            foreach (var carpool in readText)
            {
                string[] splittedCarpools = carpool.Split(';');
                var foo = new CarpoolS
                    (
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


        //Method to generate a new Id
        public int GetId()
        {
            List<string[]> AllCarpools = new List<string[]>();

            //for each line in the Carpool.csv file
            foreach (string f in File.ReadAllLines(CarpoolPath()))
            {
                //Splitten
                AllCarpools.Add(f.Split(';'));
            }
            //Convert Id to int and add +1 to the biggest number in [1] of carpool.csv
            var Id = Convert.ToInt32(AllCarpools.Max(e => e[0])) + 1;
            return Id;
        }

        //Reads all carpools and adds them to a list + RETURNS the LIST
        public List<string> ReadCarPoolList(string path)
        {
            var CarPoolList = File.ReadAllLines(path, Encoding.UTF8);
            List<string> readList = CarPoolList.ToList();
            return readList;
        }


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

        #endregion Helper Methods
    }
}
