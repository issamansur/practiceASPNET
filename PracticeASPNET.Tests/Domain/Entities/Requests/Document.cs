using AutoFixture;
using AutoFixture.Xunit2;
using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Utils;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace PracticeASPNET.Tests.Domain.Entities.Requests;

public class DocumentTests
{
    public class DocumentCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new RegularExpressionGenerator());
        }
    }

    [Theory, AutoData]
    public void Document_WithValidNameAndEmail_ShouldBeCreated(
        [RegularExpression(@"^[a-zA-Z]{2,20}$")] string validName,
        [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$")] string validEmail)
    {
        // Act
        Document document = Document.Create(validName, validEmail);

        // Assert
        Assert.NotNull(document);
        Assert.Equal(validName, document.Name);
        Assert.Equal(validEmail, document.Email);
    }

    [Theory, AutoData]
    public void Document_WithInvalidName_ShouldThrowException(
        [RegularExpression(@"^[a-zA-Z0-9._+-]{1}$")] string invalidName,
        [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$")] string validEmail)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Document.Create(invalidName, validEmail));
    }

    [Theory, AutoData]
    public void Document_WithInvalidEmail_ShouldThrowException(
        [RegularExpression(@"^[a-zA-Z]{2,20}$")] string validName,
        string invalidEmail)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Document.Create(validName, invalidEmail));
    }
}
