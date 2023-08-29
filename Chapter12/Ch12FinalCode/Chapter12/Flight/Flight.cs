using System.Diagnostics.CodeAnalysis;

namespace Packt.CloudySkiesAir.Chapter12.Flight;

public class Flight {
  [SuppressMessage("Performance", "CA1822:Mark members as static", 
    Justification = "Intend to work with instance data in future release")]
  public string BuildMessage(string id, string status) {
    return $"Flight {id} is {status}";
  }
}

