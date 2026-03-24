using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class RemoveMarker
    {
        [Fact]
        public void RemoveMarker_withValidMarker_ShouldRemoveMarkerFromUser()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, user.Id);
            user.AddMarker(marker);
            //Act
            user.RemoveMarker(marker);
            //Assert
            user.Markers.Should().NotContain(marker);
        }

        [Fact]
        public void RemoveMarker_withNullMarker_ShouldThrowArgumentNullException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            //Act
            Action actNull = () => user.RemoveMarker(null!);
            //Assert
            actNull.Should().Throw<ArgumentNullException>().WithMessage("Marker cannot be null (Parameter 'marker')");
        }

        [Fact]
        public void RemoveMarker_withMarkerNotInUserMarkers_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, user.Id);
            //Act
            Action actMarkerNotInUserMarkers = () => user.RemoveMarker(marker);
            //Assert
            actMarkerNotInUserMarkers.Should().Throw<ArgumentException>().WithMessage("Marker not found in user's markers (Parameter 'marker')");
        }

        [Fact]
        public void RemoveMarker_withMarkerHavingDifferentUserId_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, Guid.NewGuid());
            //Act
            Action actMarkerWithDifferentUserId = () => user.RemoveMarker(marker);
            //Assert
            actMarkerWithDifferentUserId.Should().Throw<ArgumentException>().WithMessage("Marker not found in user's markers (Parameter 'marker')");
        }


    }
}


