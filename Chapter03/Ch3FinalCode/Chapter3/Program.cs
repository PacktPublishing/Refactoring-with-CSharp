namespace Packt.CloudySkiesAir.Chapter3;

public class Program {
  public static void Main() {
    PassengerGenerator generator = new();
    IEnumerable<Passenger> passengers = generator.GeneratePassengers(18).OrderBy(p => p.BoardingGroup);

    BoardingProcessor boardingProcessor = new() {
      CurrentBoardingGroup = 4,
      Status = BoardingStatus.Boarding
    };

    Random random = new();

    foreach (var passenger in passengers.Where(p => boardingProcessor.CanPassengerBoard(p).StartsWith("Board"))) {
      passenger.HasBoarded = random.NextDouble() < 0.65;
    }

    boardingProcessor.DisplayBoardingStatus(passengers.ToList());
  }
}
