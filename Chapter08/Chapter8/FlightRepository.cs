using System.Data;
using System.Data.SqlClient;

namespace Packt.CloudySkiesAir.Chapter8;

public class FlightRepository : IDisposable {
  // Usually you won't have a connection string in code, but read it from a config file
  private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CloudySkies;Integrated Security=True;";

  private SqlConnection? _conn;

  public FlightInfo GetFlight(string id) {
    // Create & open connection if not currently open
    OpenConnectionIfNeeded();

    // Query the database
    using SqlCommand command = new("SELECT f.Id, f.Departure, f.Arrival, f.Miles FROM Flights f WHERE f.Id = @id", _conn);
    command.Parameters.AddWithValue("@id", id);

    using SqlDataReader reader = command.ExecuteReader();

    // return the Flight
    if (reader.Read()) {
      FlightInfo flight = GetFlightFromDataReader(reader);

      return flight;
    }

    throw new FlightNotFoundException(id);
  }

  public List<FlightInfo> GetAllFlights() {
    // Create & open connection if not currently open
    OpenConnectionIfNeeded();

    // Query the database
    using SqlCommand command = new("SELECT f.Id, f.Departure, f.Arrival, f.Miles FROM Flights f", _conn);
    using SqlDataReader reader = command.ExecuteReader();

    // return the list
    List<FlightInfo> flights = new();
    while (reader.Read()) {
      FlightInfo flight = GetFlightFromDataReader(reader);

      flights.Add(flight);
    }

    return flights;
  }

  public void Dispose() => _conn?.Dispose();

  private static FlightInfo GetFlightFromDataReader(SqlDataReader reader) {
    FlightInfo info = new();
    info.Id = reader.GetString("Id");
    info.DepartureAirport = reader.GetString("Departure");
    info.ArrivalAirport = reader.GetString("Arrival");
    info.Miles = reader.GetInt32("Miles");

    return info;
  }

  private void OpenConnectionIfNeeded() {
    _conn ??= new SqlConnection(connectionString);

    if (_conn.State == ConnectionState.Closed) {
      _conn.Open();
    }
  }
}