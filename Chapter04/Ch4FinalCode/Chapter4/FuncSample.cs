namespace Packt.CloudySkiesAir.Chapter4;

public class FuncSample {

    public static void AddAction(int x, int y) {
        int sum = x + y;
        Console.WriteLine($"{x} + {y} is {sum}");
    }

    public static string AddFunc(int x, int y) {
        int sum = x + y;
        return $"{x} + {y} is {sum}";
    }

    public static void ActionFuncVariables() {
        Action<int, int> myAction = AddAction;
        myAction(2, 2);

        Func<int, int, string> myFunc = AddFunc;
        string equation = myFunc(2, 2);
        Console.WriteLine(equation);
    }
}
