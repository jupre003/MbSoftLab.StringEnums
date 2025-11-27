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
        /// Parametrisierter Test für den Konstruktor mit verschiedenen Eingabewerten.
        /// Testet, ob der Konstruktor die übergebenen Werte korrekt speichert.
        /// </summary>
        [Theory]
        [InlineData("TrueValue", "FalseValue")]           // Normale Werte
        [InlineData("", "")]                               // Leere Strings
        [InlineData(null, null)]                           // Null-Werte
        [InlineData("TrueValue", null)]                    // Gemischte Werte (TrueValue gesetzt, FalseValue null)
        [InlineData(null, "FalseValue")]                   // Gemischte Werte (TrueValue null, FalseValue gesetzt)
        [InlineData("Ja → Wert!", "Nein ← Wert!")]        // Sonderzeichen
        public void Constructor_WithVariousInputs_SetsPropertiesCorrectly(string? trueValue, string? falseValue)
        {
            // Act
            var attribute = new ConditionalStringValueAttribute(trueValue!, falseValue!);

            // Assert
            Assert.Equal(trueValue, attribute.ValueTrue);
            Assert.Equal(falseValue, attribute.ValueFalse);
        }

        /// <summary>
        /// Testet, ob die ValueTrue-Property den korrekten Wert zurückgibt.
        /// </summary>
        [Theory]
        [InlineData("ExpectedTrueValue")]
        [InlineData("")]
        [InlineData(null)]
        public void ValueTrue_WhenAccessed_ReturnsCorrectValue(string? expectedValue)
        {
            // Arrange
            var attribute = new ConditionalStringValueAttribute(expectedValue!, "FalseValue");

            // Act
            string result = attribute.ValueTrue;

            // Assert
            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Testet, ob die ValueFalse-Property den korrekten Wert zurückgibt.
        /// </summary>
        [Theory]
        [InlineData("ExpectedFalseValue")]
        [InlineData("")]
        [InlineData(null)]
        public void ValueFalse_WhenAccessed_ReturnsCorrectValue(string? expectedValue)
        {
            // Arrange
            var attribute = new ConditionalStringValueAttribute("TrueValue", expectedValue!);

            // Act
            string result = attribute.ValueFalse;

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
