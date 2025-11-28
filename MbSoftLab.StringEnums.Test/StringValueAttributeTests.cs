using Xunit;

namespace MbSoftLab.StringEnums.Test
{
    /// <summary>
    /// Unit-Tests für das StringValueAttribute.
    /// Testet die korrekte Funktionalität des Attributs, das String-Werte für Enum-Mitglieder definiert.
    /// </summary>
    public class StringValueAttributeTests
    {
        /// <summary>
        /// Testet, ob der Konstruktor den übergebenen Wert korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithValidValue_SetsValueProperty()
        {
            // Arrange
            string expectedValue = "TestValue";

            // Act
            var attribute = new StringValueAttribute(expectedValue);

            // Assert
            Assert.Equal(expectedValue, attribute.Value);
        }

        /// <summary>
        /// Testet, ob der Konstruktor einen leeren String korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyString_SetsEmptyValue()
        {
            // Arrange
            string expectedValue = string.Empty;

            // Act
            var attribute = new StringValueAttribute(expectedValue);

            // Assert
            Assert.Equal(expectedValue, attribute.Value);
        }

        /// <summary>
        /// Testet, ob der Konstruktor einen null-Wert korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithNullValue_SetsNullValue()
        {
            // Arrange & Act
            var attribute = new StringValueAttribute(null!);

            // Assert
            Assert.Null(attribute.Value);
        }

        /// <summary>
        /// Testet, ob der Konstruktor einen Wert mit Sonderzeichen korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithSpecialCharacters_SetsValueCorrectly()
        {
            // Arrange
            string expectedValue = "Wert mit Ümläuten & Sönderzëichen!@#$%";

            // Act
            var attribute = new StringValueAttribute(expectedValue);

            // Assert
            Assert.Equal(expectedValue, attribute.Value);
        }

        /// <summary>
        /// Testet, ob der Konstruktor einen Unicode-Wert korrekt speichert.
        /// </summary>
        [Fact]
        public void Constructor_WithUnicodeCharacters_SetsValueCorrectly()
        {
            // Arrange
            string expectedValue = "日本語テスト 🎉";

            // Act
            var attribute = new StringValueAttribute(expectedValue);

            // Assert
            Assert.Equal(expectedValue, attribute.Value);
        }
    }
}
