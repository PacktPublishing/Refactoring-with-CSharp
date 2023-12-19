namespace Packt.CloudySkiesAir.Chapter8;

public static class FlightCsvReader {
  public static IEnumerable<FlightInfo> ReadFlightsFromCsv(string path) {
    string[] lines = File.ReadAllLines(path);
    foreach (string line in lines.Skip(1)) {
      yield return ReadFlightFromCsv(line);
    }
  }

  public static FlightInfo ReadFlightFromCsvRepetitive(string csvLine) {
    string[] parts = csvLine.Split(',');
    const string fallback = "Unknown";
    FlightInfo flight = new() {
      Id = parts.Length > 0
            ? parts[0]?.Trim() ?? fallback
            : fallback,
      DepartureAirport = parts.Length > 1
            ? parts[1]?.Trim() ?? fallback
            : fallback,
      ArrivalAirport = parts.Length > 2
            ? parts[2]?.Trim() ?? fallback
            : fallback
    };

    // Other parsing logic omitted
    return flight;
  }

  public static FlightInfo ReadFlightFromCsv(string csvLine) {
    string[] parts = csvLine.Split(',');

    FlightInfo flight = new() {
      Id = ReadFromCsv(parts, 0),
      DepartureAirport = ReadFromCsv(parts, 1),
      ArrivalAirport = ReadFromCsv(parts, 2)
    };

    // Other parsing logic omitted

    return flight;
  }

  static string ReadFromCsv(string[] parts, int index, string fallback = "Unknown") =>
          parts.Length > index
              ? parts[index]?.Trim() ?? fallback
              : fallback;
}
