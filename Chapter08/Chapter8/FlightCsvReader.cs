using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter8; 

public class FlightCsvReader {

  public IEnumerable<FlightInfo> ReadFlightsFromCsv(string path) {
    string[] lines = File.ReadAllLines(path);
    foreach (string line in lines.Skip(1)) {
      yield return ReadFlightFromCsv(line);
    }
  }

  public FlightInfo ReadFlightFromCsvRepetitive(string csvLine) {
    string[] parts = csvLine.Split(',');
    const string fallback = "Unknown";
    FlightInfo flight = new();

    if (parts.Length > 0) {
      flight.Id = parts[0]?.Trim() ?? fallback;
    } else {
      flight.Id = fallback;
    }

    if (parts.Length > 1) {
      flight.DepartureAirport = parts[1]?.Trim() ?? fallback;
    } else {
      flight.DepartureAirport = fallback;
    }

    if (parts.Length > 2) {
      flight.ArrivalAirport = parts[2]?.Trim() ?? fallback;
    } else {
      flight.ArrivalAirport = fallback;
    }

    // Other parsing logic omitted
    return flight;
  }

  public FlightInfo ReadFlightFromCsv(string csvLine) {
    string[] parts = csvLine.Split(',');

    FlightInfo flight = new();
    flight.Id = ReadFromCsv(parts, 0);
    flight.DepartureAirport = ReadFromCsv(parts, 1);
    flight.ArrivalAirport = ReadFromCsv(parts, 2);

    // Other parsing logic omitted

    return flight;
  }

  private string ReadFromCsv(string[] parts, int index, string fallback = "Unknown") {
    if (parts.Length > index) {
      return parts[index]?.Trim() ?? fallback;
    } else {
      return fallback;
    }
  }
}
