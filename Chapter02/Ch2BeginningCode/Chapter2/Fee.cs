namespace Packt.CloudySkiesAir.Chapter2; 

public class Fee {
  public decimal Total { get; set; }

  public void ChargeCarryOnBaggageFee(decimal fee) {
    Console.WriteLine($"Carry-on Fee: {fee}");
    Total += fee;
  }
  public void ChargeCheckedBaggageFee(decimal fee) {
    Console.WriteLine($"Checked Fee: {fee}");
    Total += fee;
  }
}
