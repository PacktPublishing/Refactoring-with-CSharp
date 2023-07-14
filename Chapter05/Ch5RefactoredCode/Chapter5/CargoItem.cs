namespace Packt.CloudySkiesAir.Chapter5;

public class CargoItem : ICargoItem {
  public string ItemType { get; set; }
  public int Quantity { get; set; }
  public void LogManifest() {
    Console.WriteLine($"Customized: {ToString()}");
  }

  public override string ToString() =>
    $"{Quantity} {ItemType}";
}
