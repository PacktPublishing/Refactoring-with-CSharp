namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

public record Airport {
  public required string Country { get; set; }
  public required string Code { get; set; }
  public required string Name { get; set; }

  public override string ToString() => Code;
}
