using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

namespace Chapter9Tests.Doubles;

public class SendingNotAllowedEmailClient : IEmailClient {
  public bool SendMessage(string email, string message) {
    Assert.Fail("You should not have sent an E-Mail");
    return false;
  }
}