using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;   
using FluentAssertions;
using Xunit;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class UserEmailUpdateTests
    {
        [Fact]
        public void EmailUpdate_withValidEmail_ShouldUpdateEmail()
        {
            //Arrange
            var user = new User("John", "Doe", "jodo@test.com", "hash", UserRole.User);
            //Act
            user.EmailUpdate("johnDo@test.com");
            //Assert
            user.Email.Should().Be("johnDo@test.com");
        }

        [Fact]
        public void EmailUpdate_withNullOrEmptyEmail_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "hash", UserRole.User);
            //Act
            Action actNull = () => user.EmailUpdate(null!);
            Action actEmpty = () => user.EmailUpdate("");
            //Assert
            actNull.Should().Throw<ArgumentException>().WithMessage("Email cannot be null or empty (Parameter 'email')");
            actEmpty.Should().Throw<ArgumentException>().WithMessage("Email cannot be null or empty (Parameter 'email')");
        }

        [Fact]
        public void EmailUpdate_withInvalidEmailFormat_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "jojo.test.com", "hash", UserRole.User);
            //Act
            Action act = () => user.EmailUpdate("jojo.test.com");
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Invalid email format (Parameter 'email')");
        }

        [Fact]
        public void EmailUpdate_withLongEmail_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "joooooooooooooooooooooooooooooooooooooooootttttttttttttttttttttttttttttttteeeeeeeeeeeeeeeeeeeeeeeeeessssssssssssssssssssssssssttttttttttttttttttttttt.@test.com", "hash", UserRole.User);
            //Act
            Action act = () => user.EmailUpdate("joooooooooooooooooooooooooooooooooooooooootttttttttttttttttttttttttttttttteeeeeeeeeeeeeeeeeeeeeeeeeessssssssssssssssssssssssssttttttttttttttttttttttt)@test.com");
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Email cannot be longer than 80 characters (Parameter 'email')");
        }
    }
}