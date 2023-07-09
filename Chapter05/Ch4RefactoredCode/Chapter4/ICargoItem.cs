namespace Packt.CloudySkiesAir.Chapter4; 

public interface ICargoItem {
  string ItemType { get; }
  int Quantity { get; }
  string ManifestText => $"{ItemType} {Quantity}";
  void LogManifest() {
    Console.WriteLine(ManifestText);
  }
}