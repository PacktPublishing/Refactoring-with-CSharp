using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

namespace Chapter9Tests.Doubles;
public class TestEmailClient : IEmailClient
{
    public bool SendMessage(string email, string message) => true;
}
