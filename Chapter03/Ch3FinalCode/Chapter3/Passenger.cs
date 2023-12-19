namespace Packt.CloudySkiesAir.Chapter3;

public class Passenger {
  public string FirstName { get; set; } = default!;
  public string LastName { get; set; } = default!;
  public int BoardingGroup { get; set; }
  public bool IsMilitary { get; set; }
  public bool NeedsHelp { get; set; }
  public bool HasBoarded { get; set; }
  public string FullName => $"{FirstName} {LastName}";

  public override string ToString() => FullName;
}