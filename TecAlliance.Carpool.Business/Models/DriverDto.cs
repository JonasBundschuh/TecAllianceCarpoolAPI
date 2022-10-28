namespace TecAlliance.Carpool.Business.Models
{
    public class DriverDto
    {
        //Create DriverDto Properties
        public int Id { get; set; }
        public int FreeSeats { get; set; }
        public string Smoke { get; set; }
        public string FullName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        //Constructor for DriverDto Properties
        public DriverDto(int freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            FreeSeats = freeSeats;
            Smoke = smoke;
            FullName = fullName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }

        public DriverDto(int id, int freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            Id = id;
            FreeSeats = freeSeats;
            Smoke = smoke;
            FullName = fullName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }

        public DriverDto()
        {

        }
    }
}
