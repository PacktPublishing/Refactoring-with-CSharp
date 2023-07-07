namespace Packt.CloudySkiesAir.Chapter5;

//---------------------------------------------------------
public class BoardingGate {
  public string CanPassengerBoard(
    bool isMilitary,
    int currentBoardingGroup,
    int boardingPassGroup,
    bool needsHelp,
    DateTime boardingStart,
    bool hasFlightDeparted) {

    int MaxPriorityLane = 3;

    if (!hasFlightDeparted) {
      DateTime time = DateTime.Now;
      if (isMilitary && time >= boardingStart) {
        return "Board Now via the Priority Lane";
      } else if (needsHelp && time >= boardingStart) {
        return "Board Now via the Priority Lane";
      } else if (time >= boardingStart) {
        if (currentBoardingGroup >= boardingPassGroup) {
          if (currentBoardingGroup <= MaxPriorityLane) {
            return "Board Now via the Priority Lane";
          } else {
            return "Board Now via the Normal Lane";
          }
        } else {
          return "Please Wait for your Group";
        }
      } else {
        return "Please Wait for Boarding to Start";
      }
    } else {
      return "You missed your flight";
    }
  }
}
