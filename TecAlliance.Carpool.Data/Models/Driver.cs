namespace TecAlliance.Carpool.Data.Models
{
    public class Driver
    {
        //Properties for Driver
        public string FreeSeats { get; set; }
        public string Smoke { get; set; }
        public string FullName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        //Constructor for Driver Properties
        public Driver(string freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            FreeSeats = freeSeats;
            Smoke = smoke;
            FullName = fullName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }
    }
}
