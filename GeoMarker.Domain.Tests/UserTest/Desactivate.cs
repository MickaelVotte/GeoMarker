using FluentAssertions;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using Xunit;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class Desactivate
    {
        [Fact]
        public void Desactivate_ShouldSetIsActiveToFalse()
        {   // Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            // Act
            user.Desactivate();
            // Assert
            user.IsActive.Should().BeFalse();
        }

        [Fact]
        public void Desactivate_ShouldNotChangeOtherProperties()
        {
            // Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            // Act
            user.Desactivate();
            // Assert
            user.IsActive.Should().Be(false);
            user.FirstName.Should().Be("John");
            user.LastName.Should().Be("Doe");
            user.Email.Should().Be("");
            user.PasswordHash.Should().Be("");
            user.Role.Should().Be(UserRole.User);
        }

        [Fact]
        public void Desactivate__ShouldDeactivateAllMarkers()
        {
            // Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker1 = new Marker("Marker 1", "Description 1", 0, 0, user.Id);
            var marker2 = new Marker("Marker 2", "Description 2", 0, 0, user.Id);
            user.AddMarker(marker1);
            user.AddMarker(marker2);
            // Act
            user.Desactivate();
            // Assert
            user.Markers.Should().AllSatisfy(m => m.IsActive.Should().BeFalse());
        }
    }   
}
