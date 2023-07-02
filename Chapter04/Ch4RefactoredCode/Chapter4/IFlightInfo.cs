using Packt.CloudySkiesAir.Chapter4.AirTravel;

namespace Packt.CloudySkiesAir.Chapter4;

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

  public override string ToString() {
    return $"{Id} {DepartureLocation.Code}-{ArrivalLocation.Code} carrying {_passengers} people";
  }
}

public class FreightFlightInfo : IFlightInfo {
  // This gets a constructor

  public string Id { get; set; }
  public Airport DepartureLocation { get; set; }
  public Airport ArrivalLocation { get; set; }
  public DateTime DepartureTime { get; set; }
  public DateTime ArrivalTime { get; set; }
  public TimeSpan Duration => DepartureTime - ArrivalTime;
  public string CharterCompany { get; set; }
  public string Cargo { get; set; }

  public override string ToString() {
    return $"{Id} {DepartureLocation.Code}-{ArrivalLocation.Code} carrying {Cargo} for {CharterCompany}";
  }
}
