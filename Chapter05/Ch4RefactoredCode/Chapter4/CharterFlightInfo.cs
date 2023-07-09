using System.Text;

namespace Packt.CloudySkiesAir.Chapter4;

public class CharterFlightInfo : FlightInfoBase {
  public List<ICargoItem> Cargo { get; } = new();

  public override string BuildFlightIdentifier() {
    StringBuilder sb = new(base.BuildFlightIdentifier());
    if (Cargo.Count != 0) {
      sb.Append(" carrying ");
      IEnumerable<string> cargoStrings = 
        Cargo.Select(c => c.ToString());
      sb.Append(string.Join(", ", cargoStrings));
    }
    return sb.ToString();
  }
}
