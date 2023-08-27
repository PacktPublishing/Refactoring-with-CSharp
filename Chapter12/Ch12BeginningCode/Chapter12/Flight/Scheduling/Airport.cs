namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;

public class Airport {
  public string Country { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }

  public override bool Equals(object? obj) {
    Airport? otherAirport = obj as Airport;

    if (otherAirport == null)
      return false;

    string otherName = otherAirport.Name;
    string otherCountry = otherAirport.Country;
    string otherCode = otherAirport.Code;

    return Country == otherCountry &&
           Code == otherCode;
  }

  public override int GetHashCode() {
    return HashCode.Combine(Country, Code);
  }

  public override string ToString() => Code;
}
