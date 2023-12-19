namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling;

public class Airport {
  public required string Country { get; set; }
  public required string Code { get; set; }
  public required string Name { get; set; }

  public override bool Equals(object? obj) {
    return obj is Airport airport &&
           Country == airport.Country &&
           Code == airport.Code;
  }

  public override int GetHashCode() {
    return HashCode.Combine(Country, Code);
  }

  public override string ToString() => Code;
}
