namespace Packt.CloudySkiesAir.Chapter2;

static class Program {
  static void Main() {
    int numChecked = 2, numCarryOn = 1, numPassengers = 2;

    BaggageCalculator baggageCalculator = new();
    DateTime travelTime = DateTime.Now;
    decimal price = baggageCalculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelTime.Month is >= 11 or <= 2);

    Console.WriteLine($"{numChecked} checked and {numCarryOn} carry-on bags for {numPassengers} passengers is {price:C}");
  }
}