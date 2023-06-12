namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {
    private const decimal CarryOnFee = 30M;
    private const decimal FirstBagFee = 40M;
    private const decimal ExtraBagFee = 50M;

    public decimal HolidayTravelFeePercent { get; set; } = 0.1M;

    public decimal CalculatePrice(int numChecked, int numCarryOn, int numPassengers, bool isHoliday) {
        decimal total = 0;

        if (numCarryOn > 0) {
            decimal carryOnFee = numCarryOn * CarryOnFee;
            Console.WriteLine($"Carry-on bag price: {carryOnFee}");
            total += carryOnFee;
        }

        if (numChecked > 0) {
            decimal checkedFee = ApplyCheckedBagFee(numChecked, numPassengers);
            Console.WriteLine($"Checked bag price: {checkedFee}");
            total += checkedFee;
        }

        if (isHoliday) {
            Console.WriteLine($"Holiday Fee: {total * HolidayTravelFeePercent}");
            total += total * HolidayTravelFeePercent;
        }

        return total;
    }

    private static decimal ApplyCheckedBagFee(int numChecked, int numPassengers) {
        decimal checkedFee;
        if (numChecked <= numPassengers) {
            checkedFee = numChecked * FirstBagFee;
        } else {
            decimal firstBagFee = numPassengers * FirstBagFee;
            int additionalBags = numChecked - numPassengers;
            decimal additionalBagFee = additionalBags * ExtraBagFee;
            checkedFee = firstBagFee + additionalBagFee;
        }
        return checkedFee;
    }
}
