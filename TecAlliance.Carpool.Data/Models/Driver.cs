namespace TecAlliance.Carpool.Data.Models
{
    public class Driver
    {
        //Properties for Driver
        public int Id { get; set; }
        public int FreeSeats { get; set; }
        public string Smoke { get; set; }
        public string FullName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        //Constructor for Driver Properties
        public Driver(int freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {
            FreeSeats = freeSeats;
            Smoke = smoke;
            FullName = fullName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }
        public Driver(int id, int freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
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

        public string ToDataString()
        {
            return $"{Id};{FreeSeats};{Smoke};{FullName};{StartLoc};{EndLoc};{TimeStart};{TimeEnd}";
        }
    }
}
