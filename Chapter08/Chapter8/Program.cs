using Packt.CloudySkiesAir.Chapter8;
using System.Data.SqlClient;

namespace Packt.CloudySkiesAir.Chapter6;

public static class Program {
  public static void Main() {
    Console.WriteLine("Welcome to the Cloudy Skies Flight Listing System");
    Console.WriteLine();

    try {
      using FlightRepository repo = new();

      Console.WriteLine("Finding flight CSA1003");
      FlightInfo myFlight = repo.GetFlight("CSA1003");
      Console.WriteLine(myFlight);

      Console.WriteLine();
      Console.WriteLine("Finding All Flights");
      foreach (FlightInfo aFlight in repo.GetAllFlights()) {
        Console.WriteLine(aFlight);
      }
    }
    catch (SqlException ex) {
      Console.WriteLine($"Trouble connecting to the Cloudy Skies database. It may not exist locally: {ex.Message}");
    }
    catch (FlightNotFoundException ex) {
      Console.WriteLine($"Could not find flight {ex.FlightId}");
    }

    Console.WriteLine();
    Console.WriteLine("Program terminating");
  }
}
