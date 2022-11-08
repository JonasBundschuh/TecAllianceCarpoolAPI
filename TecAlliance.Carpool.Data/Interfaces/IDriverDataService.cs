using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Interfaces
{
    public interface IDriverDataService
    {
        #region Main Methods

        //Add a new Driver (line) to Driver csv
        void AddNewDriver(Driver driver);

        //DELETE ALL
        void DeleteALlDrivers();

        //List of all drivers returning "driver"
        List<Driver> AllDrivers();

        //Method to Delete a driver matching the ID chosen by the User
        void DeleteDriverById(int Id);

        #endregion Main Methods



        #region HelperMethods

        List<string> ReadDriverList(string path);
        //Check if Driver file exists, if not create one
        void CheckForDriverOrCreateFile();

        //Dynamic path for Driver.csv
        string DriverPath();
        //Get a Id
        int GetId();
        #endregion Helper Methods
    }
}
