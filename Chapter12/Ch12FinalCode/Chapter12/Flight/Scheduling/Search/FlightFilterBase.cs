namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Search;

public abstract class FlightFilterBase {
  public abstract bool ShouldInclude(IFlightInfo flight);
}
