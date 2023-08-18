namespace Packt.CloudySkiesAir.Chapter9.Flight;

public class Flight {
  public string BuildMessage(string id, string status) {
    return $"Flight {id} is {status}";
  }
}

