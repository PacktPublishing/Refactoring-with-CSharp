namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Flights;

public class CargoItem : ICargoItem {
  public string ItemType { get; set; } = default!;
  public int Quantity { get; set; }
  public void LogManifest() {
    Console.WriteLine($"Customized: {ToString()}");
  }

  public override string ToString() =>
    $"{Quantity} {ItemType}";
}