namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

public record Airport {
  public string Country { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }

  public override string ToString() => Code;
}
