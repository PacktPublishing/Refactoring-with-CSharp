using System.Globalization;
using System.Text;

namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

public class CharterFlightInfo : FlightInfoBase {
  public List<ICargoItem> Cargo { get; } = new();

  public override string BuildFlightIdentifier() {
    StringBuilder sb = new(base.BuildFlightIdentifier());
    if (Cargo.Count != 0) {
      sb.Append(" carrying ");
      foreach (var cargo in Cargo) {
        sb.Append($"{cargo}, ");
      }
    }
    return sb.ToString();
  }
}