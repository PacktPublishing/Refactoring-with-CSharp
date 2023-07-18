namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Search;

public abstract class FlightFilterBase {
  public abstract bool ShouldInclude(IFlightInfo flight);
}
