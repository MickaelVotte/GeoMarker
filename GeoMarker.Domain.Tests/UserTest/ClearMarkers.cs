using FluentAssertions;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using Xunit;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class ClearMarkers
    {
        [Fact]
        public void ClearMarkers_ShouldRemoveAllMarkersFromUser()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker1 = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, user.Id);
            var marker2 = new Marker("Marker2", "Description", (decimal)30.00, (decimal)40.00, user.Id);
            user.AddMarker(marker1);
            user.AddMarker(marker2);
            //Act
            user.ClearMarkers();
            //Assert
            user.Markers.Should().BeEmpty();
        }

        [Fact]
        public void ClearMarkers_withNoMarkers_ShouldNotThrow()
        {
            // Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            // Act
            Action act = () => user.ClearMarkers();
            // Assert
            act.Should().NotThrow();
        }
    }
}
