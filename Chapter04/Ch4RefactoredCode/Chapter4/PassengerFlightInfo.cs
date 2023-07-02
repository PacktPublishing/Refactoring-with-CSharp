namespace Packt.CloudySkiesAir.Chapter4;

public class PassengerFlightInfo : IFlightInfo {
  private int _passengers;

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
