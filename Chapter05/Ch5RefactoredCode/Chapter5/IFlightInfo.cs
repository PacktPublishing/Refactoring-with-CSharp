namespace Packt.CloudySkiesAir.Chapter5;

public interface IFlightInfo {
  string Id { get; }
  AirportEvent Arrival { get; set; }
  AirportEvent Departure { get; set; }
  TimeSpan Duration { get; }
}
