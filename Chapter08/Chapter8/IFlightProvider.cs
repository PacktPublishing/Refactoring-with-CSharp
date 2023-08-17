namespace Packt.CloudySkiesAir.Chapter8;

// Note: in a real application FlightRepository would probably be expanded to support these methods
// However, in order to keep the code readable, FlightRepository does not implement all these capabilities

public interface IFlightProvider {
  FlightInfo? FindFlight(string id);
  IEnumerable<FlightInfo> GetActiveFlights();
  IEnumerable<FlightInfo> GetPendingFlights();
  IEnumerable<FlightInfo> GetCompletedFlights();
}
