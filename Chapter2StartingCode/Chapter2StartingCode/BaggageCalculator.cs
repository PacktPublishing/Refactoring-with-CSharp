using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator
{
    private decimal basePrice = 100.0M;
    public decimal BasePrice
    {
        get { return basePrice; }
        set { basePrice = value; }
    }

    public decimal CalculatePrice(int numChecked, int numCarryOn, int numPassengers)
    {
        decimal totalPrice = 0;

        decimal basePrice = BasePrice;
        if (numPassengers > 1)
        {
            basePrice += (numPassengers - 1) * (totalPrice * 0.05m);
        } 
        totalPrice += basePrice;
        Console.WriteLine("Base price: " + basePrice.ToString("C"));

        if (numChecked > 0)
        {
            decimal checkedPrice = numChecked * 25 * (numChecked > 5 ? 0.1m : 1);
            totalPrice += checkedPrice;
            Console.WriteLine("Checked bag price: " + checkedPrice.ToString("C"));
        }

        if (numCarryOn > 0)
        {
            decimal carryOnPrice = numCarryOn * 10 * (numCarryOn > 3 ? 0.05m : 1);
            totalPrice += carryOnPrice;
            Console.WriteLine("Carry-on bag price: " + carryOnPrice.ToString("C"));
        }

        return totalPrice;
    }
}
