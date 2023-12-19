namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

public class CargoItem : ICargoItem {
  public required string ItemType { get; set; }
  public int Quantity { get; set; }
  public void LogManifest() {
    Console.WriteLine($"Customized: {ToString()}");
  }

  public override string ToString() =>
    $"{Quantity} {ItemType}";
}