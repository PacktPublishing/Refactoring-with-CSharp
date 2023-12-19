using Packt.CloudySkiesAir.Chapter6.Flight.Boarding;

namespace Chapter6MSTest;

[TestClass]
public class PassengerTests {
  [TestMethod]
  [DataRow("Calvin", "Allen", "Calvin Allen")]
  [DataRow("Matthew", "Groves", "Matthew Groves")]
  [DataRow("Sam", "Gomez", "Sam Gomez")]
  [DataRow("Brad", "Knowles", "Brad Knowles")]
  [DataRow("Chris", "Ayers", "Chris Ayers")]
  public void PassengerNameShouldBeCorrect(string first, string last, string expected) {
    // Arrange
    Passenger passenger = new() {
      FirstName = first,
      LastName = last,
    };

    // Act
    string fullName = passenger.FullName;

    // Assert
    Assert.AreEqual(expected, fullName);
  }
}