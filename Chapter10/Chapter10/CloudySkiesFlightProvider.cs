using RestSharp;
using System.Runtime.CompilerServices;

using Flights = System.Collections.Generic.IEnumerable<Packt.CloudySkiesAir.Chapter10.FlightInfo>;
using Ardalis.GuardClauses;

namespace Packt.CloudySkiesAir.Chapter10;

public sealed class CloudySkiesFlightProvider : IDisposable {
  readonly RestClient _client;

  public CloudySkiesFlightProvider() {
    _client = new RestClient("https://PacktRefactoringCSharpAPI.azurewebsites.net");
  }

  public Flights GetFlightsByStatus(FlightStatus? status, string apiKey) {
    string url = status switch {
      FlightStatus.Pending => "/flights/pending",
      FlightStatus.Active => "/flights/active",
      FlightStatus.Completed => "/flights/completed",
      _ => "/flights",
    };

    RestRequest request = new(url);
    request.AddHeader("x-api-key", apiKey);

    LogApiCall(request.Resource);

    List<FlightInfo>? response = _client.Get<List<FlightInfo>>(request);

    return response ?? Enumerable.Empty<FlightInfo>();
  }

  public FlightInfo? GetFlight(string id, string apiKey) {
    ArgumentException.ThrowIfNullOrEmpty(id, nameof(id));
    ArgumentException.ThrowIfNullOrEmpty(apiKey, nameof(apiKey));

    if (!id.StartsWith("CSA", StringComparison.OrdinalIgnoreCase)) {
      throw new ArgumentOutOfRangeException(nameof(id), "Cannot lookup non-CSA flights");
    }

    RestRequest request = new($"/flights/{id.ToLower()}");
    request.AddHeader("x-api-key", apiKey);

    LogApiCall(request.Resource);

    FlightInfo? flightInfo = _client.Get<FlightInfo?>(request);

    if (flightInfo == null) {
      string message = $"Could not find flight {id}";
      throw new InvalidOperationException(message);
    }

    return flightInfo;
  }


  public Flights GetFlightsByMiles(int maxMiles, string apiKey) {
    Guard.Against.NegativeOrZero(maxMiles);
    Guard.Against.NullOrWhiteSpace(apiKey);

    RestRequest request = new($"/flights/uptodistance/{maxMiles}");
    request.AddHeader("x-api-key", apiKey);

    LogApiCall(request.Resource);

    Flights? response = _client.Get<Flights>(request);

    return response ?? Enumerable.Empty<FlightInfo>();
  }

  public static void LogApiCall(string url,
    [CallerFilePath] string file = "",
    [CallerLineNumber] int line = 0,
    [CallerMemberName] string name = "",
    [CallerArgumentExpression(nameof(url))] string expr = "") 
  {

    Console.WriteLine($"Making API Call to {url}");
    Console.WriteLine($"Called in {file}:{line} @ {name}");
    Console.WriteLine($"Url expression: {expr}");
  }

  public void Dispose() => _client.Dispose();
}

