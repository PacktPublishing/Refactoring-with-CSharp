namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {

  private decimal holidayTravelFeePercent = 0.1M;
  public decimal HolidayTravelFeePercent {
    get { return holidayTravelFeePercent; }
    set { holidayTravelFeePercent = value; }
  }

  public decimal CalculatePrice(int bags, 
    int carryOn, int passengers, DateTime travelTime) {

    decimal total = 0;

    if (carryOn > 0) {
      Console.WriteLine($"Carry-on: {carryOn * 30M}");
      total += carryOn * 30M;
    }

    if (bags > 0) {
      if (bags <= passengers) {
        Console.WriteLine($"Checked: {bags * 40M}");
        total += bags * 40M;
      } else {
        decimal checkedFee = (passengers * 40M) + 
          ((bags - passengers) * 50M);

        Console.WriteLine($"Checked: {checkedFee}");
        total += checkedFee;
      }
    }

    if (travelTime.Month >= 11 || travelTime.Month <= 2) {
      Console.WriteLine("Holiday Fee: " + 
        (total * HolidayTravelFeePercent));

      total += total * HolidayTravelFeePercent;
    }

    return total;
  }
  private decimal CalculatePriceFlat(int numBags) {
    decimal total = 0;

    return 100M;

    return numBags * 50M;
  }
}
