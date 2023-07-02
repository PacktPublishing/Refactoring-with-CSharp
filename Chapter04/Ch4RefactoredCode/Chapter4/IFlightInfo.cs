namespace Packt.CloudySkiesAir.Chapter4;

public interface IFlightInfo {
  string Id { get; }
  Airport DepartureLocation { get; }
  Airport ArrivalLocation { get; }
  DateTime DepartureTime { get; }
  DateTime ArrivalTime { get; }
  TimeSpan Duration { get; }
}
