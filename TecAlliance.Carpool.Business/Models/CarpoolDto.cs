namespace TecAlliance.Carpool.Business.Models
{
    public class CarpoolDto
    {
        public int Id { get; set; }
        public int FreeSeats { get; set; }
        public string DriverName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public CarpoolDto(int freeSeats, string driverName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            FreeSeats = freeSeats;
            DriverName = driverName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;

            
        }

        public CarpoolDto(int id, int freeSeats, string driverName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            Id = id;
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
