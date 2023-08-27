using Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Flights;

namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;

public interface IFlightInfo {
  string Id { get; }
  AirportEvent Arrival { get; }
  AirportEvent Departure { get; }
  TimeSpan Duration { get; }
  FlightStatus Status { get; set; }
}
