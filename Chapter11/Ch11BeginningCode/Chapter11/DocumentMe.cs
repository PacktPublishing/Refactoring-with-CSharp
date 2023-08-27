using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter11;

public class DocumentMe {

  public int AddEvenNumbers(int[]? numbers, int total = 0) {
    if (numbers == null || numbers.Length == 0) {
      string message = "There must be at least 1 element";
      throw new ArgumentException(message, nameof(numbers));
    }
    return total + numbers.Where(n => n % 2 == 0).Sum();
  }

}
