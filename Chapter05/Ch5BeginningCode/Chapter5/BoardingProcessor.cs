using Packt.CloudySkiesAir.Chapter5;

public class BoardingProcessor {

  public int CurrentBoardingGroup { get; set; } = 2;
  public BoardingStatus Status { get; set; }
  private int[] _priorityLaneGroups = new[] { 1, 2 };

  public void DisplayPassengers(List<Passenger> passengers) {
    foreach (Passenger passenger in passengers) {
      string boardingStatus = CanPassengerBoard(
        isMilitary: passenger.IsMilitary, 
        passenger.BoardingGroup, 
        passenger.NeedsHelp);
      Console.WriteLine($"{passenger.FullName} - Boarding Group {passenger.BoardingGroup}: {boardingStatus}");
    }
  }

  public string CanPassengerBoard(
    bool isMilitary,
    int passengerGroup,
    bool needsHelp) {

    if (Status != BoardingStatus.PlaneDeparted) {
      if (isMilitary && Status == BoardingStatus.InProgress) {
        return "Board Now via Priority Lane";
      } else if (needsHelp && Status == BoardingStatus.InProgress) {
        return "Board Now via Priority Lane";
      } else if (Status == BoardingStatus.InProgress) {
        if (CurrentBoardingGroup >= passengerGroup) {
          if (_priorityLaneGroups.Contains(passengerGroup)) {
            return "Board Now via Priority Lane";
          } else {
            return "Board Now";
          }
        } else {
          return "Please Wait";
        }
      } else {
        return "Boarding Not Started";
      }
    } else {
      return "Flight Departed";
    }
  }
}
