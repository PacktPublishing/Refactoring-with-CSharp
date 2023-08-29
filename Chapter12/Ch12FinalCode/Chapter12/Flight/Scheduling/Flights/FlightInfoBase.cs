using Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;

namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Flights;

public abstract class FlightInfoBase : IFlightInfo {
  public required AirportEvent Arrival { get; init; }
  public required AirportEvent Departure { get; init; }
  public TimeSpan Duration => Departure.Time - Arrival.Time;
  public required string Id { get; init; }
  public FlightStatus Status { get; set; } = FlightStatus.OnTime;

  public virtual string BuildFlightIdentifier() =>
    $"{Id} {Departure.Location}-{Arrival.Location}";
  public sealed override string ToString() =>
    BuildFlightIdentifier();
}