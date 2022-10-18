namespace TecAlliance.Carpool.Data.Services
{
    public class DriverdataService
    {
        int Id = 0;
        public void AddNewDriver(string freeSeats, string smoke, string fullName, string startLoc, string endLoc, string timeStart, string timeEnd)
        {

            foreach (string file in Directory.EnumerateFiles("C:\\Projects\\FahrgemeinschaftsAPP\\bin\\Fahrgemeinschaften", "*.csv"))
            {
                Id++;

            }
            File.AppendAllText($"C:\\Projects\\FahrgemeinschaftsAPP\\bin\\Fahrgemeinschaften\\Fahrgemeinschaft{Id}.csv", $"{Id};{freeSeats};{smoke};{fullName};{startLoc};{endLoc};{timeStart};{timeEnd};\n");

        }
    }
}
