namespace Packt.CloudySkiesAir.Chapter11;

public class Program {
  public static void Main() {
    RefactorMe refactorMe = new RefactorMe();
    RefactorMe.DisplayRandomNumbers();

    DocumentMe documentMe = new DocumentMe();
    DocumentMe.AddEvenNumbers([1, 2, 3], 42);
  }
}