namespace TecAlliance.Carpool.Data.Services
{
    public class DriverdataService
    {
        int Id = 0;
        public void AddNewDriver(string freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {

            foreach (string file in Directory.EnumerateFiles("C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools", "*.csv"))
            {
                Id++;

            }
            File.AppendAllText($"C:\\001\\012TecAllianceCarpoolAPI\\Bin\\Carpools\\Fahrgemeinschaft{Id}.csv", $"{Id};{freeSeats};{smoke};{fullName};{startLoc};{endLoc};{timeStart};{timeEnd};\n");

        }
    }
}
