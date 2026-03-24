using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class PasswordUpdate
    {
        [Fact]
        public void PasswordUpdate_withValidPassword_ShouldUpdatePassword()
        {
            //Arrange
            var user = new User("John", "Doe", "", "hash", UserRole.User);
            //Act
            user.PasswordUpdate("newHash");
            //Assert
            user.PasswordHash.Should().Be("newHash");
        }

        [Fact]
        public void PasswordUpdate_withNullOrEmptyPassword_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "hash", UserRole.User);
            //Act
            Action actNull = () => user.PasswordUpdate(null);
            Action actEmpty = () => user.PasswordUpdate("");
            //Assert
            actNull.Should().Throw<ArgumentException>().WithMessage("Password hash cannot be null or empty (Parameter 'passwordHash')");
            actEmpty.Should().Throw<ArgumentException>().WithMessage("Password hash cannot be null or empty (Parameter 'passwordHash')");
        }
    }
}
