namespace Packt.CloudySkiesAir.Chapter8;

public class RewardsItineraryManager : ItineraryManager {
  const int BonusMilesPerFlight = 100;
  public override void FlightCompleted(FlightInfo? nextFlight) {
    base.FlightCompleted(nextFlight);
    AccumulateMiles(BonusMilesPerFlight);
  }
  public override void ChangeFlight(FlightInfo newFlight, bool isInvoluntary) {
    if (isInvoluntary && Flight != null) {
      AccumulateMiles(Flight.Miles);
    }
    base.ChangeFlight(newFlight, isInvoluntary);
  }
}
