using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Business.Interfaces
{
    public interface ICarpoolBusinessService
    {
        //Add a carpool
        CarpoolS AddCarpool(CarpoolDto carpoolDto);
        //gets EVERY SINGLE carpool
        List<CarpoolDto> GetAllCarpools();
        //get one specific Carpool with matching ID to the one chosen by the User
        CarpoolDto? GetCarpoolByID(int CarpoolId);
        //Delete EVERY SINGLE carpool
        void DeleteAllCarpools();
        //delete one specific carpool chosen by the User (by ID)
        void DeleteCarpoolbyId(int Id);
        //edit / change information of a specific carpool chosen by the User (by ID)
        CarpoolDto? EditCarpoolByID(int CarpoolID, int FreeSeats, string NewDriver);
    }
}
