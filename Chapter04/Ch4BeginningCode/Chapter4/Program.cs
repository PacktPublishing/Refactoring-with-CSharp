namespace Packt.CloudySkiesAir.Chapter4;

internal class Program
{
    public static void Main() {
        FlightTracker flightTracker = new FlightTracker();
        flightTracker.ScheduleNewFlight("CSA2024", "CMH", DateTime.Now, "C04");
        flightTracker.ScheduleNewFlight("CSA2042", "ATL", DateTime.Now.AddMinutes(7), "C05");

        Console.WriteLine();

        flightTracker.DisplayFlights();
    }
}