namespace Packt.CloudySkiesAir.Chapter8;

// Note: in a real application FlightRepository would probably be expanded to support these methods
// However, in order to keep the code readable, FlightRepository does not implement all these capabilities

public interface IFlightUpdater {
  FlightInfo AddFlight(FlightInfo flight);
  FlightInfo UpdateFlight(FlightInfo flight);
  void CancelFlight(FlightInfo flight);
}
