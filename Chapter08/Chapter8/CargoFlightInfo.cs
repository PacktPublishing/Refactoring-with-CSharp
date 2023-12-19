namespace Packt.CloudySkiesAir.Chapter8 {
  public class CargoFlightInfo : FlightInfo {

    public decimal TonsOfCargo { get; set; }

    public override int RewardMiles => 0;
  }
}