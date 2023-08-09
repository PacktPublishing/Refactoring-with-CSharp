namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Flights;

public abstract record FlightInfoBase : IFlightInfo {
  public AirportEvent Arrival { get; set; }
  public AirportEvent Departure { get; set; }
  public TimeSpan Duration => Departure.Time - Arrival.Time;
  public string Id { get; set; }
  public FlightStatus Status { get; set; } = FlightStatus.OnTime;

  public virtual string BuildFlightIdentifier() =>
    $"{Id} {Departure.Location}-{Arrival.Location}";
  public sealed override string ToString() =>
    BuildFlightIdentifier();
}