namespace Packt.CloudySkiesAir.Chapter6.Flight.Boarding;

public class Passenger {
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public int BoardingGroup { get; set; }
  public bool IsMilitary { get; set; }
  public bool NeedsHelp { get; set; }
  public bool HasBoarded { get; set; }
  public string FullName => $"{FirstName} {LastName}";

  public override string ToString() => FullName;
}
