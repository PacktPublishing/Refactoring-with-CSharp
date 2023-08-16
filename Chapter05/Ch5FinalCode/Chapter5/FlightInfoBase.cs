namespace Packt.CloudySkiesAir.Chapter5; 

public abstract class FlightInfoBase : IFlightInfo {
  public AirportEvent Arrival { get; set; }
  public AirportEvent Departure { get; set; }
  public TimeSpan Duration => Departure.Time - Arrival.Time;
  public string Id { get; set; }
  public virtual string BuildFlightIdentifier() =>
    $"{Id} {Departure.Location}-{Arrival.Location}";
  public sealed override string ToString() =>
    BuildFlightIdentifier();
}