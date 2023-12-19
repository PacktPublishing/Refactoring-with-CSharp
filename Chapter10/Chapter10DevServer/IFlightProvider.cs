namespace Packt.CloudySkiesAir.Chapter10.DevServer;

public interface IFlightProvider {
  FlightInfo? FindFlight(string id);
  IEnumerable<FlightInfo> GetActiveFlights();
  IEnumerable<FlightInfo> GetPendingFlights();
  IEnumerable<FlightInfo> GetCompletedFlights();
  IEnumerable<FlightInfo> GetAllFlights();
  IEnumerable<FlightInfo> GetFlightsUpToMileage(int maxMiles);
}
