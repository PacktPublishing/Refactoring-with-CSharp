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
            decimal holidayFee = total * HolidayTravelFeePercent;
            Console.WriteLine($"Holiday Fee: {holidayFee}");
            total += holidayFee;
        }

        return total;
    }

    private static decimal ApplyCheckedBagFee(int numChecked, int numPassengers) {

        if (numChecked <= numPassengers) {
            return numChecked * FirstBagFee;
        }

        decimal firstBagFee = numPassengers * FirstBagFee;
        int additionalBags = numChecked - numPassengers;
        decimal additionalBagFee = additionalBags * ExtraBagFee;

        return firstBagFee + additionalBagFee;
    }
}
