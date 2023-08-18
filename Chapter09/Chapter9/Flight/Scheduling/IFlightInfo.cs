using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Flights;

namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

public interface IFlightInfo {
  string Id { get; }
  AirportEvent Arrival { get; set; }
  AirportEvent Departure { get; set; }
  TimeSpan Duration { get; }
  FlightStatus Status { get; set; }
}
