namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Search;

public class AirportFilter : FlightFilterBase {
  public bool IsDeparture { get; set; }
  public required Airport Airport { get; init; }
  public override bool ShouldInclude(IFlightInfo flight) {
    if (IsDeparture) {
      return flight.Departure.Location == Airport;
    }
    return flight.Arrival.Location == Airport;
  }
}
