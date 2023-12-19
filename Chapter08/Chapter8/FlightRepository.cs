﻿using System.Data;
using System.Data.SqlClient;

namespace Packt.CloudySkiesAir.Chapter8;

public sealed class FlightRepository : IDisposable {
  // Usually you won't have a connection string in code, but read it from a config file
  readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CloudySkies;Integrated Security=True;";

  SqlConnection? _conn;

  public FlightInfo GetFlight(string id) {
    // Create & open connection if not currently open
    OpenConnectionIfNeeded();

    // Query the database
    const string sql = "SELECT f.Id, f.Departure, f.Arrival, f.Miles FROM Flights f WHERE f.Id = @id";
    using SqlCommand command = new(sql, _conn);
    command.Parameters.AddWithValue("@id", id);

    using SqlDataReader reader = command.ExecuteReader();

    // return the Flight
    if (reader.Read()) {
      return GetFlightFromDataReader(reader);
    }

    throw new FlightNotFoundException(id);
  }

  public List<FlightInfo> GetAllFlights() {
    // Create & open connection if not currently open
    OpenConnectionIfNeeded();

    // Query the database
    const string sql = "SELECT f.Id, f.Departure, f.Arrival, f.Miles FROM Flights f";
    using SqlCommand command = new(sql, _conn);
    using SqlDataReader reader = command.ExecuteReader();

    // Return the list
    List<FlightInfo> flights = [];
    while (reader.Read()) {
      flights.Add(GetFlightFromDataReader(reader));
    }

    return flights;
  }

  public void Dispose() => _conn?.Dispose();

  static FlightInfo GetFlightFromDataReader(SqlDataReader reader) {
    FlightInfo info = new() {
      Id = reader.GetString("Id"),
      DepartureAirport = reader.GetString("Departure"),
      ArrivalAirport = reader.GetString("Arrival"),
      Miles = reader.GetInt32("Miles")
    };

    return info;
  }

  void OpenConnectionIfNeeded() {
    _conn ??= new SqlConnection(connectionString);

    if (_conn.State == ConnectionState.Closed) {
      _conn.Open();
    }
  }
}