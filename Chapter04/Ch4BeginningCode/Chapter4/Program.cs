namespace Packt.CloudySkiesAir.Chapter4;

internal class Program
{
    public static void Main() {
        FlightTracker flightTracker = new();

        Random rand = new();
        string[] destinations = { "CMH", "ATL", "MCI", "CLT", "SAN", "ORD", "CHS", "PNS" };
        string[] gates = { "A01", "A02", "A03", "A04", "C01", "C02", "C03", "C04" };
        int nextId = 2024;

        DateTime nextFlightTime = DateTime.Now;
        for (int i = 0; i < 15; i++) {
            nextFlightTime = nextFlightTime.AddMinutes(rand.Next(1, 25));

            AddRandomFlight(flightTracker, rand, destinations, gates, nextId, nextFlightTime);

            nextId += rand.Next(1, 7);
        }

        Console.WriteLine();
        Console.WriteLine("FLIGHT    DEST  DEPARTURE             GATE  STATUS");
        Console.WriteLine();
        flightTracker.DisplayFlights();
    }

    private static void AddRandomFlight(FlightTracker flightTracker, Random rand, string[] destinations, string[] gates, int nextId, DateTime nextFlightTime) {
        string dest = destinations[rand.Next(destinations.Length)];
        string gate = gates[rand.Next(gates.Length)];
        Flight flight = flightTracker.ScheduleNewFlight($"CSA{nextId}", dest, nextFlightTime, gate);

        _ = rand.Next(8) switch {
            0 => flight.Status = FlightStatus.Inbound,
            1 => flight.Status = FlightStatus.Delayed,
            2 => flight.Status = FlightStatus.Cancelled,
            _ => flight.Status = FlightStatus.OnTime
        };
    }
}
