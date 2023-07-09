namespace Packt.CloudySkiesAir.Chapter3.Tests;

public class PassengerTests {
    [Theory]
    [InlineData("John", "Doe", "John Doe")]
    [InlineData("Jane", "Doe", "Jane Doe")]
    [InlineData("Jim", "Smith", "Jim Smith")]
    public void Fullname_ShouldReturnFirstNameAndLastName(string first, string last, string expected) {
        // Arrange
        Passenger p = Build(first, last);

        // Act
        string actual = p.FullName;

        // Assert
        Assert.Equal(expected, actual);
    }

    private Passenger Build(string firstName, string lastName) {
        Passenger passenger = new() {
            FirstName = firstName,
            LastName = lastName
        };

        return passenger;
    }
}
