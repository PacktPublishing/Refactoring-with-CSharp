namespace Packt.CloudySkiesAir.Chapter4;

internal class Program
{
    public static void Main() {
        Console.WriteLine("Do you want to do a flight with a layover or a direct flight? (l/d)");
        string response = Console.ReadLine()!;

        FlightBase? selectedFlight = null;
        DateTime departureTime = DateTime.Now;
        switch (response.ToLowerInvariant()) {
            case "l":
                selectedFlight = new FlightWithLayover("CMH", "MCI", departureTime.AddHours(1.5), TimeSpan.FromHours(3), departureTime, "DFW", TimeSpan.FromHours(2.75));
                break;
            case "d":
                selectedFlight = new DirectFlight("CMH", departureTime, "MCI", departureTime.AddHours(3));
                break;
        }

        if (selectedFlight != null) {
            Console.WriteLine(selectedFlight.ToString());
        } else {
            Console.WriteLine("Invalid selection");
        }
    }
}