namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {
    private decimal holidayTravelFeePercent = 0.1M;
    public decimal HolidayTravelFeePercent {
        get { return holidayTravelFeePercent; }
        set { holidayTravelFeePercent = value; }
    }

    public decimal CalculatePrice(int numChecked, int numCarryOn, 
        int numPassengers, DateTime travelTime) {
        decimal totalPrice = 0;

        if (numCarryOn > 0) {
            decimal totCarryOn = numCarryOn * 30.00M;
            Console.WriteLine($"Carry-on bag price: {totCarryOn:C}");
            totalPrice += totCarryOn;
        }

        if (numChecked > 0) {
            decimal totChecked = 0;
            if (numChecked <= numPassengers) {
                totChecked = numChecked * 40.00M;
                Console.WriteLine($"Checked bag price: {totChecked:C}");
                totalPrice += totChecked;
            } else {
                totChecked = numPassengers * 40.00M;
                totChecked += (numChecked - numPassengers) * 50.00M;
                Console.WriteLine($"Checked bag price: {totChecked:C}");
                totalPrice += totChecked;
            }
        }

        if (travelTime.Month >= 11 || travelTime.Month <= 2) {
            decimal holidayTravelFee = totalPrice * HolidayTravelFeePercent;
            Console.WriteLine($"Holiday Travel Fee: {holidayTravelFee:C}");
            totalPrice += holidayTravelFee;
        }

        return totalPrice;
    }
}
