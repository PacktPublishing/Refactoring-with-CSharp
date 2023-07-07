namespace Packt.CloudySkiesAir.Chapter4;

public class Airport {
  public string Country { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }

  public override bool Equals(object? obj) {
    return obj is Airport airport &&
           Country == airport.Country &&
           Code == airport.Code;
  }

  public override int GetHashCode() {
    return HashCode.Combine(Country, Code);
  }

  public override string? ToString() => Code;
}
