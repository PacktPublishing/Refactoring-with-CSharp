using System;
using Xunit;

namespace Packt.CloudySkiesAir.Chapter5.Tests
{
    public class PassengerTests
    {
        [Theory]
        [InlineData("John", "Doe", "John Doe", 1, false, false)]
        [InlineData("Jane", "Doe", "Jane Doe", 2, true, false)]
        [InlineData("Jim", "Smith", "Jim Smith", 3, false, true)]
        public void Fullname_ShouldReturnFirstNameAndLastName(string firstName, string lastName, 
            string expectedFullName, int boardingGroup, bool isMilitary, bool needsHelp)
        {
            var passenger = new Passenger()
            {
                FirstName = firstName,
                LastName = lastName,
                BoardingGroup = boardingGroup,
                IsMilitary = isMilitary,
                NeedsHelp = needsHelp
            };

            Assert.Equal(expectedFullName, passenger.FullName);
        }
    }
}
