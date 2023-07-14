using Packt.CloudySkiesAir.Chapter5.AirTravel;
using System;

namespace Packt.CloudySkiesAir.Chapter5 {
  public class Program {
    public static void Main() {
      Airport dep = new() {
        Code = "DNA",
        Country = "United States",
        Name = "Dotnet Airport"
      };
      Airport arr = new() {
        Code = "CSI",
        Country = "United Kingdom",
        Name = "C# International Airport"
      };

      FlightScheduler scheduler = new();
      scheduler.ScheduleFlight("CS2001", dep, arr, DateTime.Now.AddMinutes(20), DateTime.Now.AddHours(6.5), 680);
      scheduler.ScheduleFlight("CS2023", arr, dep, DateTime.Now.AddMinutes(-40), DateTime.Now.AddHours(6.1), 930);

      Console.WriteLine();
      Console.WriteLine("All Flights:");
      foreach (IFlightInfo flight in scheduler.GetAllFlights()) {
        Console.WriteLine(flight);
      }

      Console.WriteLine();
      Console.WriteLine($"Flights to {arr.Name}:");
      IEnumerable<IFlightInfo> filteredList = scheduler.Search(null, arr, null, null, null, null, null, null);
      foreach (IFlightInfo flight in filteredList) {
        Console.WriteLine(flight);
      }
    }
  }
}
