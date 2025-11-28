using Xunit;

namespace MbSoftLab.StringEnums.Test
{
    /// <summary>
    /// Unit-Tests für die CustomStringValueExtensions-Klasse.
    /// Testet die korrekte Funktionalität der benutzerdefinierten Extension-Methode.
    /// </summary>
    public class CustomStringValueExtensionsTests
    {
        /// <summary>
        /// Testet, ob GetCustomStringValue den korrekten Wert zurückgibt, wenn ein CustomStringValueAttribute vorhanden ist.
        /// </summary>
        [Fact]
        public void GetCustomStringValue_WithAttribute_ReturnsAttributeValue()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetCustomStringValue();

            // Assert
            Assert.Equal("MyCustomStringValue1", result);
        }

        /// <summary>
        /// Testet, ob GetCustomStringValue einen leeren String zurückgibt, wenn das CustomStringValueAttribute einen leeren Wert hat.
        /// </summary>
        [Fact]
        public void GetCustomStringValue_AttributeWithEmptyValue_ReturnsEmptyString()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue2;

            // Act
            var result = enumValue.GetCustomStringValue();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Testet, ob GetCustomStringValue null zurückgibt, wenn kein CustomStringValueAttribute vorhanden ist.
        /// </summary>
        [Fact]
        public void GetCustomStringValue_NoAttribute_ReturnsNull()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.DummyValue1;

            // Act
            var result = enumValue.GetCustomStringValue();

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Testet, ob GetCustomStringValue unabhängig von anderen Attributen den korrekten Wert zurückgibt.
        /// </summary>
        [Fact]
        public void GetCustomStringValue_WithMultipleAttributes_ReturnsOnlyCustomValue()
        {
            // Arrange - DummyValue1 hat sowohl StringValue als auch CustomStringValue
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var customResult = enumValue.GetCustomStringValue();
            var stringValueResult = enumValue.GetStringValue();

            // Assert
            Assert.Equal("MyCustomStringValue1", customResult);
            Assert.Equal("MyStringValue1", stringValueResult);
            Assert.NotEqual(customResult, stringValueResult);
        }
    }
}
