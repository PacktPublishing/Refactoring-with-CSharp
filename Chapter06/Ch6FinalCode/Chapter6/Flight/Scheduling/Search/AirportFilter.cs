namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Search;

public class AirportFilter : FlightFilterBase {
  public bool IsDeparture { get; set; }
  public required Airport Airport { get; set; }
  public override bool ShouldInclude(IFlightInfo flight) {
    if (IsDeparture) {
      return flight.Departure.Location == Airport;
    }
    return flight.Arrival.Location == Airport;
  }
}
