namespace Packt.CloudySkiesAir.Chapter4.Filters;

public abstract class FlightFilterBase {
  public abstract bool ShouldInclude(IFlightInfo flight);
}
