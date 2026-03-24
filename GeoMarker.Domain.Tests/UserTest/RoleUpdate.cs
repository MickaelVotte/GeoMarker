using FluentAssertions;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using System.Data;
using Xunit;

namespace GeoMarker.Domain.Tests.UserTest
{
    public class RoleUpdate
    {
        [Fact]
        public void RoleUpdate_withValidRole_ShouldUpdateRole()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            //Act
            user.RoleUpdate(UserRole.Admin);
            //Assert
            user.Role.Should().Be(UserRole.Admin);
        }


        [Fact]
        public void RoleUpdate_withSameRole_ShouldUpdateRole()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            //Act
            user.RoleUpdate(UserRole.User);
            //Assert
            user.Role.Should().Be(UserRole.User);
        }

        [Fact]
        public void RoleUpdate_withInvalidRole_ShouldUpdateRole()
        {
            //Arrange
            var user = new User("John", "Doe", "", "", UserRole.User);
            //Act
            Action actInvalidRole = () => user.RoleUpdate((UserRole)999);
            //Assert
            actInvalidRole.Should().Throw<ArgumentException>().WithMessage("Invalid user role (Parameter 'role')");
        
        }
    }
}
