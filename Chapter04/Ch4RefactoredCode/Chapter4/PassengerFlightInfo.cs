namespace Packt.CloudySkiesAir.Chapter4;

public sealed class PassengerFlightInfo : FlightInfoBase {
  private int _passengers;

  public void Load(int passengers) => 
    _passengers = passengers;

  public void Unload() => 
    _passengers = 0;

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" carrying {_passengers} people";
}
