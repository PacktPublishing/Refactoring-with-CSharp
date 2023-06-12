namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {
    private decimal holidayTravelFeePercent = 0.1M;
    public decimal HolidayTravelFeePercent {
        get { return holidayTravelFeePercent; }
        set { holidayTravelFeePercent = value; }
    }

    public decimal CalculatePrice(int numChecked, int numCarryOn,
        int numPassengers, DateTime travelTime) {
        decimal total = 0;

        if (numCarryOn > 0) {
            Console.WriteLine($"Carry-on bag price: {numCarryOn * 30M}");
            total += numCarryOn * 30M;
        }

        if (numChecked > 0) {
            if (numChecked <= numPassengers) {
                Console.WriteLine($"Checked bag price: {numChecked * 40M}");
                total += numChecked * 40M;
            } else {
                decimal checkedFee = (numPassengers * 40M) + ((numChecked - numPassengers) * 50M);
                Console.WriteLine($"Checked bag price: {checkedFee}");
                total += checkedFee;
            }
        }

        if (travelTime.Month >= 11 || travelTime.Month <= 2) {
            Console.WriteLine($"Holiday Fee: {total * HolidayTravelFeePercent}");
            total += total * HolidayTravelFeePercent;
        }

        return total;
    }
    private decimal CalculatePriceFlat(int numBags) {
        decimal total = numBags * 35.5M;

        // Business says to use a flat 100 regardless of count
        return 100M;
    }
}
