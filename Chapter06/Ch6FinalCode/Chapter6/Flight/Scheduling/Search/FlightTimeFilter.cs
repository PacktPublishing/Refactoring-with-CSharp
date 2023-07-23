namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Search;

public class FlightTimeFilter : FlightFilterBase {
  public DateTime? MinTime { get; set; }
  public DateTime? MaxTime { get; set; }
  public bool IsDeparture { get; set; }

  public override bool ShouldInclude(IFlightInfo flight) {
    DateTime time = IsDeparture
      ? flight.Departure.Time
      : flight.Arrival.Time;

    return MinTime.HasValue && time < MinTime
      || MaxTime.HasValue && time > MaxTime;
  }
}