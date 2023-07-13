using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter4; 

public class FuncSample {

    public void AddAction(int x, int y) {
        int sum = x + y;
        Console.WriteLine($"{x} + {y} is {sum}");
    }

    public string AddFunc(int x, int y) {
        int sum = x + y;
        return $"{x} + {y} is {sum}";
    }

    public void ActionFuncVariables() {
        Action<int, int> myAction = AddAction;
        myAction(2, 2);

        Func<int, int, string> myFunc = AddFunc;
        string equation = myFunc(2, 2);
        Console.WriteLine(equation);
    }
}
