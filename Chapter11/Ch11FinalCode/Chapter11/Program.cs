namespace Packt.CloudySkiesAir.Chapter11;

public class Program {
  public static void Main() {
    RefactorMe refactorMe = new RefactorMe();
    refactorMe.DisplayRandomNumbers();

    DocumentMe documentMe = new DocumentMe();
    documentMe.AddEvenNumbers(new int[] { 1, 2, 3 }, 42);
  }
}