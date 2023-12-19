using Packt.CloudySkiesAir.Chapter9.Flight.Boarding;

namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling {
  public class RewrittenManifestGenerator {
    public static FlightManifest Build(FlightInfo flight) {

      IReadOnlyDictionary<string, Passenger> bookings = flight.CurrentBookings;

      return new FlightManifest() {
        Departure = flight.Departure,
        Arrival = flight.Arrival,
        PassengerCount = bookings.Count,
        BookedSeats = bookings.Keys.OrderBy(k => k).ToArray(),
        Passengers = bookings.Values
          .OrderBy(p => p.LastName)
          .ThenBy(p => p.FirstName)
          .ToArray()
      };
    }
  }

}