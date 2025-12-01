# API Reference

> **Commit Reference:** `be2d13051e07c898966cbbee29172b9941101de5` (v1.0.2)

This document provides a complete reference for all public classes, attributes, and extension methods in the MbSoftLab.StringEnums library.

## Namespace

```csharp
namespace MbSoftLab.StringEnums
```

---

## Attributes

### StringValueAttribute

A base attribute for associating a string value with an enum member.

```csharp
[AttributeUsage(AttributeTargets.Field)]
public class StringValueAttribute : Attribute
```

#### Constructor

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string value to associate with the enum member |

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Value` | `string` | Gets the associated string value |

#### Example

```csharp
public enum Priority
{
    [StringValue("low")]
    Low,
    
    [StringValue("medium")]
    Medium,
    
    [StringValue("high")]
    High
}
```

---

### ConditionalStringValueAttribute

An attribute for associating two string values with an enum member, to be selected based on a boolean condition.

```csharp
[AttributeUsage(AttributeTargets.Field)]
public class ConditionalStringValueAttribute : Attribute
```

#### Constructor

| Parameter | Type | Description |
|-----------|------|-------------|
| `valueTrue` | `string` | The string value returned when the condition is `true` |
| `valueFalse` | `string` | The string value returned when the condition is `false` |

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueTrue` | `string` | Gets the string value for the true condition |
| `ValueFalse` | `string` | Gets the string value for the false condition |

#### Example

```csharp
public enum ToggleState
{
    [ConditionalStringValue("visible", "hidden")]
    Visibility,
    
    [ConditionalStringValue("active", "inactive")]
    Activity
}
```

---

## Extension Methods

### StringEnumExtensions Class

Provides extension methods for enum types to retrieve associated string values.

```csharp
public static class StringEnumExtensions
```

---

### GetStringValue

Retrieves the string value associated with an enum member via the `[StringValue]` attribute.

```csharp
public static string GetStringValue(this Enum value)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `Enum` | The enum value |

#### Returns

- `string`: The associated string value, or an empty string if no `[StringValue]` attribute is found.

#### Example

```csharp
public enum Status
{
    [StringValue("pending")]
    Pending
}

string result = Status.Pending.GetStringValue(); // "pending"
```

---

### GetStringValueByCondition

Retrieves one of two string values associated with an enum member based on a boolean condition.

```csharp
public static string GetStringValueByCondition(this Enum value, bool condition)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `Enum` | The enum value |
| `condition` | `bool` | The condition to determine which value to return |

#### Returns

- `string`: The `ValueTrue` if condition is `true`, `ValueFalse` if condition is `false`, or an empty string if no `[ConditionalStringValue]` attribute is found.

#### Example

```csharp
public enum Switch
{
    [ConditionalStringValue("ON", "OFF")]
    Power
}

string onResult = Switch.Power.GetStringValueByCondition(true);   // "ON"
string offResult = Switch.Power.GetStringValueByCondition(false); // "OFF"
```

---

### GetAttributesFromEnum<TAttribute>

Retrieves all attributes of a specific type from an enum member.

```csharp
public static TAttribute[] GetAttributesFromEnum<TAttribute>(this Enum value)
```

#### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TAttribute` | The type of attribute to retrieve |

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `Enum` | The enum value |

#### Returns

- `TAttribute[]`: An array of attributes of the specified type.

#### Example

```csharp
public enum Example
{
    [StringValue("test")]
    TestValue
}

StringValueAttribute[] attrs = Example.TestValue.GetAttributesFromEnum<StringValueAttribute>();
```

---

### GetValueFromAttribute<TAttribute>

Retrieves the string value from a custom attribute that extends `StringValueAttribute`.

```csharp
public static string GetValueFromAttribute<TAttribute>(this Enum value) 
    where TAttribute : StringValueAttribute
```

#### Type Parameters

| Parameter | Constraint | Description |
|-----------|------------|-------------|
| `TAttribute` | `StringValueAttribute` | Must inherit from `StringValueAttribute` |

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `Enum` | The enum value |

#### Returns

- `string`: The value from the attribute, or `null` if the attribute is not found.

#### Example

```csharp
// Custom attribute
public class CssClassAttribute : StringValueAttribute
{
    public CssClassAttribute(string value) : base(value) { }
}

// Custom extension method using GetValueFromAttribute
public static class MyExtensions
{
    public static string GetCssClass(this Enum value)
    {
        return value.GetValueFromAttribute<CssClassAttribute>();
    }
}

// Usage
public enum Button
{
    [CssClass("btn-primary")]
    Primary
}

string css = Button.Primary.GetCssClass(); // "btn-primary"
```

---

## See Also

- [Quick Start Guide](./quickstart.md)
- [Advanced Usage](./advanced-usage.md)
- [Architecture](./architecture/README.md)
