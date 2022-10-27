﻿using System.Reflection;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class DriverBusinessService
    {

        //Create new DriverdataService
        DriverdataService driverDataSercice = new DriverdataService();


        //[x]
        //POST
        //Add a new driver
        public Driver AddDriver(DriverDto driverDto)
        {
            var driver = ConvertDriverDtoToDriver(driverDto);
            driverDataSercice.AddNewDriver(driver);
            return driver;

        }


        //[x]
        //GET ALL
        //Methods that gets ALL DRIVERS and RETURNS them in a LIST
        public List<DriverDto> GetAllDrivers()
        {
            CheckIfDriverFileExist();
            List<Driver> everyDriver = driverDataSercice.AllDrivers();
            List<DriverDto> AllDrivers = new List<DriverDto>();
            foreach (Driver line in everyDriver)
            {
                DriverDto driverDto = ConvertDriverList(line);
                AllDrivers.Add(driverDto);
            }
            return AllDrivers;
        }

        //[x]
        //DLELETE ALL DRIVERS
        //Deletes all drivers by deleting the whole Driver.csv file
        public void DeleteAllDrivers()
        {
            driverDataSercice.DeleteALlDrivers();
        }


        //[x]
        //DELETE BY ID
        //Method to delete a driver by the ID chosen by the User
        public DriverDto? DeleteDriverbyID(int DriverId)
        {
            //Go thru all strings in Deriver file
            var currentList = driverDataSercice.AllDrivers();
            //Create List for later, Has the same content from Driver file but without the deleted one
            List<Driver> UpdatedList = new List<Driver>();
            //Create a new (empty) DriverDto
            var DeletedDriver = new DriverDto() { };

            //for each driverDataSet (Driver) in currentList (Driver file) do:
            foreach (Driver driverDataSet in currentList)
            {
                //if the Driver ID the user entered doesn'tmatches a ID in Driver file do:
                //string[] AllDrivers = Convert.ToString(driverDataSet).Split(';');
                if (!(DriverId == driverDataSet.Id))
                {
                    //Add updated content to Updated List
                    UpdatedList.Add(driverDataSet);
                }
                else
                {
                    //Give each prop their place
                    DeletedDriver.FreeSeats = Convert.ToInt32(driverDataSet.FreeSeats);
                    DeletedDriver.Smoke = driverDataSet.Smoke;
                    DeletedDriver.FullName = driverDataSet.FullName;
                    DeletedDriver.StartLoc = driverDataSet.StartLoc;
                    DeletedDriver.EndLoc = driverDataSet.EndLoc;
                    DeletedDriver.TimeStart = driverDataSet.TimeStart;
                    DeletedDriver.TimeEnd = driverDataSet.TimeEnd;
                }
            }
            if (UpdatedList.Count() == currentList.Count())
            {
                return null;
            }
            //Rewrite the Driver csv
            foreach (var newDriverItem in UpdatedList)
            {
                driverDataSercice.AddNewDriver(newDriverItem);
            }
            return DeletedDriver;
        }


        //[x]
        //GET BY ID
        //Method to get/display a single driver by its ID (chosen by the user)
        public DriverDto? GetDriverByID(int DriverId)
        {
            //check if the Driver file exists

            //read all strings (driver) in Driver file
            var AllDrivers = driverDataSercice.AllDrivers();
            //Create a new DriverDto
            DriverDto ChosenDriver = new DriverDto();

            //for each string (driver) in Driver file (AllDrivers) do:
            foreach (Driver driver in AllDrivers)
            {
                if (DriverId == driver.Id)
                {
                    ChosenDriver.FreeSeats = Convert.ToInt32(driver.FreeSeats);
                    ChosenDriver.Smoke = driver.Smoke;
                    ChosenDriver.FullName = driver.FullName;
                    ChosenDriver.StartLoc = driver.StartLoc;
                    ChosenDriver.EndLoc = driver.EndLoc;
                    ChosenDriver.TimeStart = driver.TimeStart;
                    ChosenDriver.TimeEnd = driver.TimeEnd;
                }
            }

            //Alternative to check if the driver with the ID entered by the user even exists
            if (String.IsNullOrEmpty(ChosenDriver.FullName))
            {
                return null;
            }
            return ChosenDriver;
        }



        //[x]
        //UPDATE
        //Method to edit a existing Driver by the ID entered by the User
        public DriverDto? EditDriverByID(int DriverID, string newDriverName, string NowSmoker)
        {
            DriverDto chosenDriver = new DriverDto();
            var Alldrivers = driverDataSercice.AllDrivers();

            List<Driver> UpdatedList = new List<Driver>();

            foreach (Driver driver in Alldrivers)
            {
                if (DriverID == driver.Id)
                {
                    chosenDriver.FreeSeats = driver.FreeSeats;
                    chosenDriver.Smoke = driver.Smoke;
                    chosenDriver.FullName = driver.FullName;
                    chosenDriver.StartLoc = driver.StartLoc;
                    chosenDriver.EndLoc = driver.EndLoc;
                    chosenDriver.TimeStart = driver.TimeStart;
                    chosenDriver.TimeEnd = driver.TimeEnd;

                    driver.Smoke = NowSmoker;
                    driver.FullName = newDriverName;

                    UpdatedList.Add(ConvertDriverDtoToDriver(chosenDriver));
                }
                else
                {
                    UpdatedList.Add(driver);
                }
            }
            foreach (var newEntry in UpdatedList)
            {
                driverDataSercice.AddNewDriver(newEntry);
            }
            if (String.IsNullOrEmpty(chosenDriver.EndLoc))
            {
                return null;
            }

            return chosenDriver;
        }



        #region HelperMethods

        //Checks if Driver.csv exists
        public void CheckIfDriverFileExist()
        {
            FileStream fs = File.Create(DriverPath());
            if (File.Exists(DriverPath()))
            {

            }
            else
            {
                File.Create(DriverPath());
            }
        }


        //Method for dynamic path of Driver File exists
        public string DriverPath()
        {
            var originalpath = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(originalpath);
            string FinalPath = Path.Combine(path, @"..\..\..\..\..\", "TecAlliance.Carpool.Api\\TecAlliance.Carpool.Data\\CSV-Files\\Driver.csv");
            return FinalPath.ToString();
        }


        //Method to Convert DriverDto to driver
        public Driver ConvertDriverDtoToDriver(DriverDto driverDto)
        {
            var convertedDriver = new Driver(driverDto.FreeSeats, driverDto.Smoke, driverDto.FullName, driverDto.StartLoc, driverDto.EndLoc, driverDto.TimeStart, driverDto.TimeEnd);
            return convertedDriver;
        }

        //Method to convert Driver List
        public DriverDto ConvertDriverList(Driver driver)
        {
            var convertedDriverList = new DriverDto(driver.FreeSeats, driver.Smoke, driver.FullName, driver.StartLoc, driver.EndLoc, driver.TimeStart, driver.TimeEnd);
            return convertedDriverList;
        }
        #endregion
    }
}
