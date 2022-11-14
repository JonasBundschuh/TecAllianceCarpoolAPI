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
        void AddNewCarpool(CarpoolS carpool);

        //DELETE BY ID
        //Method to delete a single carpool with matching ID to the ID chosen by the User
        void DeleteSpecificCarpool(int Id);

        //GET All
        //List of all Carpools
        List<CarpoolS> AllCarpools();

        //DELETE All
        //delete Carpool file
        void DeleteAllCarpools();





        #endregion Main Methods






        #region Helper Methods


        //Method to generate a new Id
        int GetId();

        //Reads all carpools and adds them to a list + RETURNS the LIST
        List<string> ReadCarPoolList(string path);


        //Checks if Carpoolfile exists, if not create one
        void CheckForOrCreateCarpoolFile();


        //Get the Carpool file path dynamically
        string CarpoolPath();
        #endregion Helper Methods
    }
}
