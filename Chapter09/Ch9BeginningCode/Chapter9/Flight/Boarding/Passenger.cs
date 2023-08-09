namespace Packt.CloudySkiesAir.Chapter9.Flight.Boarding;

public class Passenger {
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int BoardingGroup { get; set; }
  public bool IsMilitary { get; set; }
  public bool NeedsHelp { get; set; }
  public bool HasBoarded { get; set; }
  public int RewardMiles { get; set; }
  public int FlightsThisYear { get; set; }
  public string Email { get; set; }
  public string RewardsId { get; set; }
  public string MailingCity { get; set; }
  public string MailingCountry { get; set; }
  public string MailingStateOrProvince { get; set; }
  public string MailingPostalCode { get; set; }
  public string FullName => $"{FirstName} {LastName}";

  public override string ToString() => FullName;
}
