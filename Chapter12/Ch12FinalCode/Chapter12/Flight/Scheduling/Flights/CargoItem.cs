namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Flights;

public class CargoItem : ICargoItem {
  public required string ItemType { get; init; }
  public int Quantity { get; set; }
  public void LogManifest() {
    Console.WriteLine($"Customized: {ToString()}");
  }

  public override string ToString() =>
    $"{Quantity} {ItemType}";
}