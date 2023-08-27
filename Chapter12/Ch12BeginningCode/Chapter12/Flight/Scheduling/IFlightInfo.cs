using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling;

public interface IFlightInfo {
  string Id { get; }
  AirportEvent Arrival { get; }
  AirportEvent Departure { get; }
  TimeSpan Duration { get; }
  FlightStatus Status { get; set; }
}
