namespace Packt.CloudySkiesAir.Chapter8; 

public class SpecificMailClient: IEmailClient {
  readonly string connectionString;

  public SpecificMailClient(string connectionString) {
    this.connectionString = connectionString;
  }

  public void SendMessage(string email, string message) {
    // Pretend this sends an email for real
    Console.WriteLine($"Sending email to {email}: {message}");
  }
}