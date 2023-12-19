namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Flights;

public record PassengerFlightInfo : FlightInfoBase {
  public int Passengers { get; private set; }

  public void Load(int passengers) =>
    Passengers = passengers;

  public void Unload() =>
    Passengers = 0;

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" carrying {Passengers} people";
}