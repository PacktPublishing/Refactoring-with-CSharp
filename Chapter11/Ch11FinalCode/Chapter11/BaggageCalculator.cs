namespace Packt.CloudySkiesAir.Chapter11;

public class BaggageCalculator {
  const decimal CarryOnFee = 30M;
  const decimal FirstBagFee = 40M;
  const decimal ExtraBagFee = 50M;

  public decimal HolidayFeePercent { get; set; } = 0.1M;

  public decimal CalculatePrice(int bags, int carryOn,
    int passengers, bool isHoliday) {

    decimal total = 0;

    void addFeeToTotal(string name, decimal fee) {
      Console.WriteLine($"{name}: {fee}");
      total += fee;
    }

    if (carryOn > 0) {
      decimal fee = carryOn * CarryOnFee;
      addFeeToTotal("Carry-on", fee);
    }

    if (bags > 0) {
      decimal bagFee = ApplyCheckedBagFee(bags, passengers);
      addFeeToTotal("Checked", bagFee);
    }

    if (isHoliday) {
      decimal holidayFee = total * HolidayFeePercent;
      addFeeToTotal("Holiday Fee", holidayFee);
    }

    return total;
  }

  static decimal ApplyCheckedBagFee(int bags,
    int passengers) {
    if (bags <= passengers) {
      decimal firstBagFee = bags * FirstBagFee;
      return firstBagFee;
    } else {
      decimal firstBagFee = passengers * FirstBagFee;
      decimal extraBagFee = (bags - passengers) * ExtraBagFee;
      decimal checkedFee = firstBagFee + extraBagFee;
      return checkedFee;
    }
  }
}
