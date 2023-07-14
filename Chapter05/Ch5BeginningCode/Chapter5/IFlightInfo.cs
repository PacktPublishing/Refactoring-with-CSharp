using Packt.CloudySkiesAir.Chapter5.AirTravel;

namespace Packt.CloudySkiesAir.Chapter5;

public interface IFlightInfo {
  string Id { get; }
  Airport DepartureLocation { get; }
  Airport ArrivalLocation { get; }
  DateTime DepartureTime { get; }
  DateTime ArrivalTime { get; }
  TimeSpan Duration { get; }
}

public class PassengerFlightInfo : IFlightInfo {
  private int _passengers;

  // This gets a constructor

  public string Id { get; set; }
  public Airport DepartureLocation { get; set; }
  public Airport ArrivalLocation { get; set; }
  public DateTime DepartureTime { get; set; }
  public DateTime ArrivalTime { get; set; }
  public TimeSpan Duration => DepartureTime - ArrivalTime;

  public void Load(int passengers) {
    _passengers = passengers;
  }

  public void Unload() {
    _passengers = 0;
  }

  public string BuildFlightIdentifier() =>
    $"{Id} {DepartureLocation.Code}-" +
    $"{ArrivalLocation.Code} carrying " +
    $"{_passengers} people";

  public override string ToString() => BuildFlightIdentifier();
}

public class FreightFlightInfo : IFlightInfo {
  public string Id { get; set; }
  public Airport DepartureLocation { get; set; }
  public Airport ArrivalLocation { get; set; }
  public DateTime DepartureTime { get; set; }
  public DateTime ArrivalTime { get; set; }
  public TimeSpan Duration => DepartureTime - ArrivalTime;
  public string CharterCompany { get; set; }
  public string Cargo { get; set; }

  public string BuildFlightIdentifier() =>
    $"{Id} {DepartureLocation.Code}-" +
    $"{ArrivalLocation.Code} carrying " +
    $"{Cargo} for {CharterCompany}";

  public override string ToString() => BuildFlightIdentifier();
}
