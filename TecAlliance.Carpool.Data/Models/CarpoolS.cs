namespace TecAlliance.Carpool.Data.Models
{
    public class CarpoolS
    {
        public int Id { get; set; }
        public string FreeSeats { get; set; }
        public string DriverName { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public string TimeDepart { get; set; }
        public string TimeArrive { get; set; }
        public CarpoolS(string freeSeats, string driverName, string startLoc, string endLoc, string timeDepart, string timeArrive)
        {
            FreeSeats = freeSeats;
            DriverName = driverName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeDepart = timeDepart;
            TimeArrive = timeArrive;
        }
        public CarpoolS(int id, string freeSeats, string driverName, string startLoc, string endLoc, string timeDepart, string timeArrive)
        {
            Id = id;
            FreeSeats = freeSeats;
            DriverName = driverName;
            StartLoc = startLoc;
            EndLoc = endLoc;
            TimeDepart = timeDepart;
            TimeArrive = timeArrive;
        }
        public string ToDataString()
        {
            return $"{Id};{FreeSeats};{DriverName};{StartLoc};{EndLoc};{TimeDepart};{TimeArrive}";
        }
    }
}
