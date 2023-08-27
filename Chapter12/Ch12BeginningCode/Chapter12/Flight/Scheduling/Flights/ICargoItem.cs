namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

public interface ICargoItem {
  string ItemType { get; }
  int Quantity { get; }
  string ManifestText => $"{ItemType} {Quantity}";
  void LogManifest() {
    Console.WriteLine(ManifestText);
  }
}