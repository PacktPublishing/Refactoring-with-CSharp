namespace Packt.CloudySkiesAir.Chapter8;

public class FlightNotFoundException : Exception {
  public string FlightId { get; }
  public FlightNotFoundException(string flightId) {
    FlightId = flightId;
  }
}
