using System;

namespace Packt.CloudySkiesAir.Chapter4 {
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
      scheduler.ScheduleFlight("CS2024", arr, dep, DateTime.Now.AddMinutes(-40), DateTime.Now.AddHours(6.1), 930);

      CharterFlightInfo charterFlight = new() {
        Id="CS2025",
        Arrival = new AirportEvent(arr, DateTime.Now.AddHours(3)),
        Departure = new AirportEvent(dep, DateTime.Now),
      };
      charterFlight.Cargo.Add(new CargoItem { ItemType = "Passengers", Quantity = 6 });
      charterFlight.Cargo.Add(new CargoItem { ItemType = "Bags", Quantity = 8 });
      scheduler.ScheduleFlight(charterFlight);

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

