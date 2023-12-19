namespace Packt.CloudySkiesAir.Chapter8;

public class FlightInfo {
  public required string Id { get; set; }
  public required string DepartureAirport { get; set; }
  public required string ArrivalAirport { get; set; }
  public int Miles { get; set; }

  public virtual int RewardMiles => Miles;

  public override string? ToString() =>
    $"Flight {Id} from {DepartureAirport} to {ArrivalAirport}";
}
