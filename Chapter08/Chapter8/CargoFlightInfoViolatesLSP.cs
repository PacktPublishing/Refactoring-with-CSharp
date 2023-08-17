using Packt.CloudySkiesAir.Chapter8;

public class CargoFlightInfoViolatesLSP : FlightInfo {

  public decimal TonsOfCargo { get; set; }

  public override int RewardMiles => 
    throw new NotSupportedException("Cargo Flights do not provide reward miles");
}
