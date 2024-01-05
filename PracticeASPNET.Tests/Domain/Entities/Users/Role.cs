using PracticeASPNET.Domain.Entities.Users;


namespace PracticeASPNET.Tests.Domain.Entities.Users;

public class RoleTests
{
    [Theory, AutoData]
    public void CreateRole_ValidName_ShouldCreateRole(
        [RegularExpression(@"^[a-zA-Z]{2,20}$")] string roleName
        )
    {
        // Arrange
        var validName = roleName;

        // Act
        var role = Role.Create(validName);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(validName, role.Name);
        Assert.NotEqual(Guid.Empty, role.Id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("a")] // Less than 2 characters
    [InlineData("a2345678901234567890")] // More than 20 characters
    [InlineData("Invalid@Name")] // Contains invalid characters
    public void CreateRole_InvalidName_ShouldThrowArgumentException(string invalidName)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Role.Create(invalidName));
    }

    [Theory, AutoData]
    public void CreateRole_DuplicateName_ShouldCreateRolesWithDifferentIds(
        [RegularExpression(@"^[a-zA-Z]{2,20}$")] string roleName
        )
    {
        // Arrange

        // Act
        var role1 = Role.Create(roleName);
        var role2 = Role.Create(roleName);

        // Assert
        Assert.NotEqual(role1.Id, role2.Id);
    }
}
