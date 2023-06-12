namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator
{
    private int maxCarryOnBagsPerPerson = 1;
    public int MaxCarryBagsPerPerson
    {
        get { return maxCarryOnBagsPerPerson; }
        set { maxCarryOnBagsPerPerson = value; }
    }

    public decimal CalculatePrice(int numChecked, int numCarryOn, int numPassengers)
    {
        if (numCarryOn > numPassengers * MaxCarryBagsPerPerson)
            throw new ArgumentException("More carry-on bags than allowed");

        decimal totalPrice = 0;

        if (numCarryOn > 0)
        {
            decimal totCarryOn = MaxCarryBagsPerPerson * numCarryOn;
            totalPrice += totCarryOn * 30.00M;
            Console.WriteLine($"Carry-on bag price: {totCarryOn:C}");
        }

        if (numChecked > 0)
        {
            decimal totChecked = 0;
            if (numChecked <= numPassengers)
            {
                totChecked = numChecked * 40.00M;

                totalPrice += totChecked;
                Console.WriteLine($"Checked bag price: {totChecked:C}");
            }
            else
            {
                totChecked = numPassengers * 40.00M;
                totChecked += (numChecked - numPassengers) * 50.00M;

                totalPrice += totChecked;
                Console.WriteLine($"Checked bag price: {totChecked:C}");
            }
        }

        return totalPrice;
    }
}
