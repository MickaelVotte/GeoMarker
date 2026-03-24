using FluentAssertions;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using Xunit;


namespace GeoMarker.Domain.Tests.UserTest
{
    public class AddMarker
    {
        [Fact]
        public void AddMarker_withValidMarker_ShouldAddMarkerToUser()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, user.Id);
            //Act
            user.AddMarker(marker);
            //Assert
            user.Markers.Should().Contain(marker);
        }

        [Fact]
        public void AddMarker_withNullMarker_ShouldThrowArgumentNullException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            //Act
            Action actNull = () => user.AddMarker(null!);
            //Assert
            actNull.Should().Throw<ArgumentNullException>().WithMessage("Marker cannot be null (Parameter 'marker')");
        }

        [Fact]
        public void AddMarker_withMarkerHavingDifferentUserId_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, Guid.NewGuid());
            //Act
            Action actInvalidUserId = () => user.AddMarker(marker);
            //Assert
            actInvalidUserId.Should().Throw<ArgumentException>().WithMessage("Marker's UserId does not match the user's Id (Parameter 'marker')");
        }

        [Fact]
        public void AddMarker_withDuplicateMarker_ShouldThrowArgumentException()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, user.Id);
            user.AddMarker(marker);
            //Act
            Action actDuplicateMarker = () => user.AddMarker(marker);
            //Assert
            actDuplicateMarker.Should().Throw<ArgumentException>().WithMessage("Marker with the same Id already exists for this user (Parameter 'marker')");
        }

        [Fact]
        public void AddMarker_withMarkerHavingSameName_ShouldAllowAddingMarker()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            var marker1 = new Marker("Marker1", "Description", (decimal)10.00, (decimal)20.00, user.Id);
            var marker2 = new Marker("Marker1", "Description", (decimal)15.00, (decimal)25.00, user.Id);
            user.AddMarker(marker1);
            //Act
            Action actSameName = () => user.AddMarker(marker2);
            //Assert
            actSameName.Should().NotThrow();
            user.Markers.Should().Contain(marker2);
        }
    }
}
