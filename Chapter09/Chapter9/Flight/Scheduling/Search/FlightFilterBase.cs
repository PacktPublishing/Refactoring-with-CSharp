namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Search;

public abstract class FlightFilterBase {
  public abstract bool ShouldInclude(IFlightInfo flight);
}
