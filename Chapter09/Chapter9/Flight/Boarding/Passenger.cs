namespace Packt.CloudySkiesAir.Chapter9.Flight.Boarding;

public class Passenger {
  public Passenger() {
  }

  public Passenger(string firstName, string lastName) {
    FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
    LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
  }

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
  public string MailingState { get; set; }
  public string MailingPostalCode { get; set; }
  public string FullName => $"{FirstName} {LastName}";

  public override string ToString() => FullName;
}
