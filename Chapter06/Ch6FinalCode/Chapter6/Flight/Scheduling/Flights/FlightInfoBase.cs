namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

public abstract class FlightInfoBase : IFlightInfo {
  public AirportEvent Arrival { get; set; } = default!;
  public AirportEvent Departure { get; set; } = default!;
  public TimeSpan Duration => Departure.Time - Arrival.Time;
  public string Id { get; set; } = default!;
  public FlightStatus Status { get; set; } = FlightStatus.OnTime;

  public virtual string BuildFlightIdentifier() =>
    $"{Id} {Departure.Location}-{Arrival.Location}";
  public sealed override string ToString() =>
    BuildFlightIdentifier();
}