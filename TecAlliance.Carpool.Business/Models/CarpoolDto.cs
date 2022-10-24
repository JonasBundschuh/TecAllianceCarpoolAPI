namespace TecAlliance.Carpool.Business.Models
{
    public class CarpoolDto
    {
        public string FreeSeats { get; set; }
        public string DriverName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public CarpoolDto(string freeSeats, string driverName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            FreeSeats = freeSeats;
            DriverName = driverName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;

            
        }
        public CarpoolDto()
        {

        }
    }        
}
