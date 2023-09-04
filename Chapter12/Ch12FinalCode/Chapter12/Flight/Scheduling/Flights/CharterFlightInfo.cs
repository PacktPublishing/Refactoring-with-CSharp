using System.Globalization;
using System.Text;

namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Flights;

public class CharterFlightInfo : FlightInfoBase {
  public List<ICargoItem> Cargo { get; }

  public CharterFlightInfo() {
    Cargo = new();
  }

  public override string BuildFlightIdentifier() {
    StringBuilder sb = new(base.BuildFlightIdentifier());
    if (Cargo.Count != 0) {
      sb.Append(" carrying ");
      foreach (var cargo in Cargo) {
        sb.Append(CultureInfo.InvariantCulture, $"{cargo}, ");
      }
    }
    return sb.ToString();
  }
}