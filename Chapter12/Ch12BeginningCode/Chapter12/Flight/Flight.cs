namespace Packt.CloudySkiesAir.Chapter12.Flight;

public class Flight {
  public string BuildMessage(string id, string status) {
    return $"Flight {id} is {status}";
  }
}

