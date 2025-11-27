using Xunit;

namespace MbSoftLab.StringEnums.Test
{
    /// <summary>
    /// Unit-Tests für das ConditionalStringValueAttribute.
    /// Testet die korrekte Funktionalität des Attributs, das bedingte String-Werte für Enum-Mitglieder definiert.
    /// </summary>
    public class ConditionalStringValueAttributeTests
    {
        /// <summary>
        /// Testet, ob der Konstruktor die übergebenen Werte korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithValidValues_SetsPropertiesCorrectly()
        {
            // Arrange
            string expectedTrueValue = "TrueValue";
            string expectedFalseValue = "FalseValue";

            // Act
            var attribute = new ConditionalStringValueAttribute(expectedTrueValue, expectedFalseValue);

            // Assert
            Assert.Equal(expectedTrueValue, attribute.ValueTrue);
            Assert.Equal(expectedFalseValue, attribute.ValueFalse);
        }

        /// <summary>
        /// Testet, ob der Konstruktor leere Strings korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyStrings_SetsEmptyValues()
        {
            // Arrange
            string expectedTrueValue = string.Empty;
            string expectedFalseValue = string.Empty;

            // Act
            var attribute = new ConditionalStringValueAttribute(expectedTrueValue, expectedFalseValue);

            // Assert
            Assert.Equal(expectedTrueValue, attribute.ValueTrue);
            Assert.Equal(expectedFalseValue, attribute.ValueFalse);
        }

        /// <summary>
        /// Testet, ob der Konstruktor null-Werte korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithNullValues_SetsNullValues()
        {
            // Arrange & Act
            var attribute = new ConditionalStringValueAttribute(null!, null!);

            // Assert
            Assert.Null(attribute.ValueTrue);
            Assert.Null(attribute.ValueFalse);
        }

        /// <summary>
        /// Testet, ob der Konstruktor gemischte Werte (null und nicht-null) korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithMixedValues_SetsValuesCorrectly()
        {
            // Arrange
            string expectedTrueValue = "TrueValue";
            string? expectedFalseValue = null;

            // Act
            var attribute = new ConditionalStringValueAttribute(expectedTrueValue, expectedFalseValue!);

            // Assert
            Assert.Equal(expectedTrueValue, attribute.ValueTrue);
            Assert.Null(attribute.ValueFalse);
        }

        /// <summary>
        /// Testet, ob die ValueTrue-Property den korrekten Wert zurückgibt.
        /// </summary>
        [Fact]
        public void ValueTrue_WhenAccessed_ReturnsCorrectValue()
        {
            // Arrange
            string expectedValue = "ExpectedTrueValue";
            var attribute = new ConditionalStringValueAttribute(expectedValue, "FalseValue");

            // Act
            string result = attribute.ValueTrue;

            // Assert
            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Testet, ob die ValueFalse-Property den korrekten Wert zurückgibt.
        /// </summary>
        [Fact]
        public void ValueFalse_WhenAccessed_ReturnsCorrectValue()
        {
            // Arrange
            string expectedValue = "ExpectedFalseValue";
            var attribute = new ConditionalStringValueAttribute("TrueValue", expectedValue);

            // Act
            string result = attribute.ValueFalse;

            // Assert
            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Testet, ob der Konstruktor Sonderzeichen korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithSpecialCharacters_SetsValuesCorrectly()
        {
            // Arrange
            string expectedTrueValue = "Ja → Wert!";
            string expectedFalseValue = "Nein ← Wert!";

            // Act
            var attribute = new ConditionalStringValueAttribute(expectedTrueValue, expectedFalseValue);

            // Assert
            Assert.Equal(expectedTrueValue, attribute.ValueTrue);
            Assert.Equal(expectedFalseValue, attribute.ValueFalse);
        }
    }
}
