namespace Packt.CloudySkiesAir.Chapter4;

public class PassengerFlightInfo : FlightInfoBase, IFlightInfo {
  private int _passengers;

  public void Load(int passengers) {
    _passengers = passengers;
  }

  public void Unload() {
    _passengers = 0;
  }

  public override string ToString() {
    return $"{Id} {DepartureLocation}-{ArrivalLocation} carrying {_passengers} people";
  }
}
