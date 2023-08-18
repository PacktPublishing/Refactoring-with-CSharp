namespace Packt.CloudySkiesAir.Chapter8;

public class ItineraryManager {
  public int MilesAccumulated { get; private set; }
  public FlightInfo? Flight { get; private set; }

  public virtual void FlightCompleted(FlightInfo? nextFlight) {
    if (Flight != null) {
      AccumulateMiles(Flight.Miles);
    }
    Flight = nextFlight;
  }

  public virtual void ChangeFlight(FlightInfo newFlight, bool isInvoluntary) =>
    Flight = newFlight;

  public void AccumulateMiles(int miles) =>
    MilesAccumulated += miles;

}

