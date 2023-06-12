using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator
{
    public decimal CalculatePrice(int numChecked, int numCarryOn, int numPassengers)
    {
        decimal totalPrice = 0;

        if (numPassengers > 1)
        {
            totalPrice = 100;
            totalPrice = ((numPassengers - 1) * (totalPrice * 0.05m)) + 100;
            Console.WriteLine("Base price: " + totalPrice.ToString("C"));
        } 
        else
        {
            totalPrice = 100;
            Console.WriteLine("Base price: " + totalPrice.ToString("C"));
        }

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

        if (totalPrice > 500)
        {
            decimal discount = totalPrice * 0.1m;
            Console.WriteLine("Big spender discount: " + discount.ToString("C"));
            totalPrice -= discount;
        }

        return totalPrice;
    }
}
