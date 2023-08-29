namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;

public class Airport {
  public required string Country { get; set; }
  public required string Code { get; set; }
  public required string Name { get; set; }

  public override bool Equals(object? obj) {
    if (obj is not Airport otherAirport)
      return false;

    string otherCountry = otherAirport.Country;
    string otherCode = otherAirport.Code;

    return Country == otherCountry &&
           Code == otherCode;
  }

  public override int GetHashCode() => 
    HashCode.Combine(Country, Code);

  public override string ToString() => Code;
}
