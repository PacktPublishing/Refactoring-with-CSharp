namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

public interface IEmailClient {
  bool SendMessage(string email, string message);
}