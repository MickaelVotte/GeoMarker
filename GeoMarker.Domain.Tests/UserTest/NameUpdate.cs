using FluentAssertions;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class NameUpdate
    {
        [Fact]
        public void NameUpdate_withValidNames_ShouldUpdateNames()
        {
            //Arrange
            var user = new User("John", "Doe", "johndodo@test.com", "hash", UserRole.User);
            //Act
            user.NameUpdate("Jane", "Smith");
            //Assert
            user.FirstName.Should().Be("Jane");
            user.LastName.Should().Be("Smith");
        }

        [Fact]
        public void NameUpdate_withNullOrEmptyFirstName_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "johndodo@test.com", "hash", UserRole.User);
            //Act
            Action actNull = () => user.NameUpdate(null!, "Smith");
            Action actEmpty = () => user.NameUpdate("", "Smith");
            //Assert
            actNull.Should().Throw<ArgumentException>().WithMessage("First name cannot be null or empty (Parameter 'firstName')");
            actEmpty.Should().Throw<ArgumentException>().WithMessage("First name cannot be null or empty (Parameter 'firstName')");
        }

        [Fact]
        public void NameUpdate_withNullOrEmptyLastName_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "hash", UserRole.User);
            //Act
            Action actNull = () => user.NameUpdate("Jane", null!);
            Action actEmpty = () => user.NameUpdate("Jane", "");
            //Assert
            actNull.Should().Throw<ArgumentException>().WithMessage("Last name cannot be null or empty (Parameter 'lastName')");
            actEmpty.Should().Throw<ArgumentException>().WithMessage("Last name cannot be null or empty (Parameter 'lastName')");
        }
    }
}