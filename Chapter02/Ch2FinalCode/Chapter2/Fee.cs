namespace Packt.CloudySkiesAir.Chapter2;

public class Fee {
  public decimal Total { get; set; }

  public void ChargeFee(decimal fee, string chargeName) {
    Console.WriteLine($"{chargeName}: {fee}");
    Total += fee;
  }
}
