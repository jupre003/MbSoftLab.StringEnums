using Xunit;

namespace MbSoftLab.StringEnums.Test
{
    /// <summary>
    /// Erweiterte Unit-Tests für die StringEnumExtensions-Klasse.
    /// Testet Edge-Cases und alle Branches der Extension-Methoden.
    /// </summary>
    public class StringEnumExtensionsTests
    {
        #region GetStringValue Tests

        /// <summary>
        /// Testet, ob GetStringValue einen leeren String zurückgibt, wenn das Enum-Mitglied kein StringValueAttribute hat.
        /// Deckt den Branch ab, bei dem stringValueAttribs.Length < 1 ist.
        /// </summary>
        [Fact]
        public void GetStringValue_NoAttribute_ReturnsEmptyString()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.DummyValue1;

            // Act
            var result = enumValue.GetStringValue();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Testet, ob GetStringValue den korrekten String-Wert zurückgibt, wenn das Enum-Mitglied ein StringValueAttribute hat.
        /// </summary>
        [Fact]
        public void GetStringValue_WithAttribute_ReturnsAttributeValue()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetStringValue();

            // Assert
            Assert.Equal("MyStringValue1", result);
        }

        /// <summary>
        /// Testet, ob GetStringValue null zurückgibt, wenn das StringValueAttribute mit null initialisiert wurde.
        /// </summary>
        [Fact]
        public void GetStringValue_AttributeWithNullValue_ReturnsNull()
        {
            // Arrange
            var enumValue = DummyEnum.NullValue;

            // Act
            var result = enumValue.GetStringValue();

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Testet, ob GetStringValue einen leeren String zurückgibt, wenn das StringValueAttribute mit einem leeren String initialisiert wurde.
        /// </summary>
        [Fact]
        public void GetStringValue_AttributeWithEmptyValue_ReturnsEmptyString()
        {
            // Arrange
            var enumValue = DummyEnum.EmptyValue;

            // Act
            var result = enumValue.GetStringValue();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Testet, ob GetStringValue den korrekten Wert zurückgibt, wenn mehrere Attribute vorhanden sind.
        /// </summary>
        [Fact]
        public void GetStringValue_MultipleAttributes_ReturnsFirstAttributeValue()
        {
            // Arrange - DummyValue1 hat sowohl StringValue als auch CustomStringValue
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetStringValue();

            // Assert
            Assert.Equal("MyStringValue1", result);
        }

        #endregion

        #region GetStringValueByCondition Tests

        /// <summary>
        /// Testet, ob GetStringValueByCondition einen leeren String zurückgibt, wenn das Enum-Mitglied kein ConditionalStringValueAttribute hat.
        /// Deckt den Branch ab, bei dem conditionalValueAttribs.Length < 1 ist.
        /// </summary>
        [Fact]
        public void GetStringValueByCondition_NoAttribute_ReturnsEmptyString()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.ConditionalValue;

            // Act
            var result = enumValue.GetStringValueByCondition(true);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Testet, ob GetStringValueByCondition einen leeren String zurückgibt, wenn die Bedingung false ist und kein Attribut vorhanden ist.
        /// </summary>
        [Fact]
        public void GetStringValueByCondition_NoAttributeConditionFalse_ReturnsEmptyString()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.ConditionalValue;

            // Act
            var result = enumValue.GetStringValueByCondition(false);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Testet, ob GetStringValueByCondition den TrueValue zurückgibt, wenn die Bedingung true ist.
        /// </summary>
        [Fact]
        public void GetStringValueByCondition_ConditionTrue_ReturnsTrueValue()
        {
            // Arrange
            var enumValue = DummyEnum.ConditionalValue;

            // Act
            var result = enumValue.GetStringValueByCondition(true);

            // Assert
            Assert.Equal("trueValue", result);
        }

        /// <summary>
        /// Testet, ob GetStringValueByCondition den FalseValue zurückgibt, wenn die Bedingung false ist.
        /// </summary>
        [Fact]
        public void GetStringValueByCondition_ConditionFalse_ReturnsFalseValue()
        {
            // Arrange
            var enumValue = DummyEnum.ConditionalValue;

            // Act
            var result = enumValue.GetStringValueByCondition(false);

            // Assert
            Assert.Equal("falseValue", result);
        }

        #endregion

        #region GetAttributesFromEnum Tests

        /// <summary>
        /// Testet, ob GetAttributesFromEnum ein leeres Array zurückgibt, wenn keine Attribute vorhanden sind.
        /// </summary>
        [Fact]
        public void GetAttributesFromEnum_NoAttributes_ReturnsEmptyArray()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.DummyValue1;

            // Act
            var result = enumValue.GetAttributesFromEnum<StringValueAttribute>();

            // Assert
            Assert.Empty(result);
        }

        /// <summary>
        /// Testet, ob GetAttributesFromEnum die korrekten Attribute zurückgibt.
        /// Da CustomStringValueAttribute von StringValueAttribute erbt, werden beide Attribute zurückgegeben.
        /// </summary>
        [Fact]
        public void GetAttributesFromEnum_WithAttribute_ReturnsAttributeArray()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetAttributesFromEnum<StringValueAttribute>();

            // Assert
            // DummyValue1 hat sowohl StringValueAttribute als auch CustomStringValueAttribute,
            // und da CustomStringValueAttribute von StringValueAttribute erbt, werden beide zurückgegeben
            Assert.Equal(2, result.Length);
            Assert.Contains(result, a => a.Value == "MyStringValue1");
            Assert.Contains(result, a => a.Value == "MyCustomStringValue1");
        }

        /// <summary>
        /// Testet, ob GetAttributesFromEnum ein Custom-Attribut korrekt zurückgibt.
        /// </summary>
        [Fact]
        public void GetAttributesFromEnum_WithCustomAttribute_ReturnsCustomAttributeArray()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetAttributesFromEnum<CustomStringValueAttribute>();

            // Assert
            Assert.Single(result);
            Assert.Equal("MyCustomStringValue1", result[0].Value);
        }

        /// <summary>
        /// Testet, ob GetAttributesFromEnum ein ConditionalStringValueAttribute korrekt zurückgibt.
        /// </summary>
        [Fact]
        public void GetAttributesFromEnum_WithConditionalAttribute_ReturnsAttributeArray()
        {
            // Arrange
            var enumValue = DummyEnum.ConditionalValue;

            // Act
            var result = enumValue.GetAttributesFromEnum<ConditionalStringValueAttribute>();

            // Assert
            Assert.Single(result);
            Assert.Equal("trueValue", result[0].ValueTrue);
            Assert.Equal("falseValue", result[0].ValueFalse);
        }

        #endregion

        #region GetValueFromAttribute Tests

        /// <summary>
        /// Testet, ob GetValueFromAttribute null zurückgibt, wenn keine Attribute vorhanden sind.
        /// Deckt den Branch ab, bei dem stringValueAttribs.Length < 1 ist.
        /// </summary>
        [Fact]
        public void GetValueFromAttribute_NoAttribute_ReturnsNull()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.DummyValue1;

            // Act
            var result = enumValue.GetValueFromAttribute<StringValueAttribute>();

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Testet, ob GetValueFromAttribute null zurückgibt, wenn kein CustomStringValueAttribute vorhanden ist.
        /// </summary>
        [Fact]
        public void GetValueFromAttribute_NoCustomAttribute_ReturnsNull()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.DummyValue2;

            // Act
            var result = enumValue.GetValueFromAttribute<CustomStringValueAttribute>();

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Testet, ob GetValueFromAttribute den korrekten Wert zurückgibt, wenn ein Attribut vorhanden ist.
        /// </summary>
        [Fact]
        public void GetValueFromAttribute_WithAttribute_ReturnsValue()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetValueFromAttribute<StringValueAttribute>();

            // Assert
            Assert.Equal("MyStringValue1", result);
        }

        /// <summary>
        /// Testet, ob GetValueFromAttribute mit CustomStringValueAttribute den korrekten Wert zurückgibt.
        /// </summary>
        [Fact]
        public void GetValueFromAttribute_WithCustomAttribute_ReturnsValue()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var result = enumValue.GetValueFromAttribute<CustomStringValueAttribute>();

            // Assert
            Assert.Equal("MyCustomStringValue1", result);
        }

        /// <summary>
        /// Testet, ob GetValueFromAttribute einen leeren String zurückgibt, wenn das Attribut einen leeren Wert hat.
        /// </summary>
        [Fact]
        public void GetValueFromAttribute_AttributeWithEmptyValue_ReturnsEmptyString()
        {
            // Arrange - DummyValue2 hat CustomStringValue("")
            var enumValue = DummyEnum.DummyValue2;

            // Act
            var result = enumValue.GetValueFromAttribute<CustomStringValueAttribute>();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        #endregion

        #region Integration Tests

        /// <summary>
        /// Testet, ob alle Extension-Methoden mit demselben Enum-Wert korrekt funktionieren.
        /// </summary>
        [Fact]
        public void AllMethods_WithSameEnumValue_WorkCorrectly()
        {
            // Arrange
            var enumValue = DummyEnum.DummyValue1;

            // Act
            var stringValue = enumValue.GetStringValue();
            var customValue = enumValue.GetValueFromAttribute<CustomStringValueAttribute>();
            var attributes = enumValue.GetAttributesFromEnum<StringValueAttribute>();

            // Assert
            Assert.Equal("MyStringValue1", stringValue);
            Assert.Equal("MyCustomStringValue1", customValue);
            // Da CustomStringValueAttribute von StringValueAttribute erbt, werden beide Attribute zurückgegeben
            Assert.Equal(2, attributes.Length);
        }

        /// <summary>
        /// Testet, ob alle Extension-Methoden mit einem Enum ohne Attribute korrekt funktionieren.
        /// </summary>
        [Fact]
        public void AllMethods_WithEnumWithoutAttributes_ReturnDefaultValues()
        {
            // Arrange
            var enumValue = DummyEnumWithMissingAttribs.DummyValue1;

            // Act
            var stringValue = enumValue.GetStringValue();
            var conditionalValue = enumValue.GetStringValueByCondition(true);
            var attributeValue = enumValue.GetValueFromAttribute<StringValueAttribute>();
            var attributes = enumValue.GetAttributesFromEnum<StringValueAttribute>();

            // Assert
            Assert.Equal(string.Empty, stringValue);
            Assert.Equal(string.Empty, conditionalValue);
            Assert.Null(attributeValue);
            Assert.Empty(attributes);
        }

        #endregion
    }
}
