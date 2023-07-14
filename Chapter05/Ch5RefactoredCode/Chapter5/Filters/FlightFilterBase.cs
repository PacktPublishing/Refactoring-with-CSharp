namespace Packt.CloudySkiesAir.Chapter5.Filters;

public abstract class FlightFilterBase {
  public abstract bool ShouldInclude(IFlightInfo flight);
}
