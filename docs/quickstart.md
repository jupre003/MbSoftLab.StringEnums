# Quick Start Guide

> **Commit Reference:** `be2d13051e07c898966cbbee29172b9941101de5` (v1.0.2)

This guide will help you get started with MbSoftLab.StringEnums in just a few minutes.

## Basic Usage

### 1. Simple String Values

The most common use case is attaching a string value to an enum member:

```csharp
using MbSoftLab.StringEnums;

public enum MyEnum
{
    [StringValue("my-css-class-1")]
    Class1,

    [StringValue("my-css-class-2")]
    Class2
}

// Usage
Console.WriteLine(MyEnum.Class1.GetStringValue()); // Output: my-css-class-1
Console.WriteLine(MyEnum.Class2.GetStringValue()); // Output: my-css-class-2
```

### 2. Conditional String Values

When you need to return different strings based on a condition:

```csharp
using MbSoftLab.StringEnums;

public enum ButtonState
{
    [ConditionalStringValue("btn-active", "btn-inactive")]
    Toggle,
    
    [ConditionalStringValue("text-success", "text-danger")]
    StatusIndicator
}

// Usage
bool isActive = true;
Console.WriteLine(ButtonState.Toggle.GetStringValueByCondition(isActive)); 
// Output: btn-active

bool isSuccess = false;
Console.WriteLine(ButtonState.StatusIndicator.GetStringValueByCondition(isSuccess)); 
// Output: text-danger
```

### 3. Multiple Attributes on Same Enum Member

You can apply multiple attributes to a single enum member:

```csharp
using MbSoftLab.StringEnums;

public enum UIElement
{
    [StringValue("primary-button")]
    [ConditionalStringValue("enabled", "disabled")]
    PrimaryButton
}

// Usage
Console.WriteLine(UIElement.PrimaryButton.GetStringValue()); 
// Output: primary-button

Console.WriteLine(UIElement.PrimaryButton.GetStringValueByCondition(true)); 
// Output: enabled
```

## Handling Edge Cases

### Missing Attributes

If an enum member doesn't have a `[StringValue]` attribute, `GetStringValue()` returns an empty string:

```csharp
public enum SimpleEnum
{
    NoAttribute
}

Console.WriteLine(SimpleEnum.NoAttribute.GetStringValue()); 
// Output: (empty string)
```

### Null or Empty Values

The library handles null and empty values gracefully:

```csharp
public enum TestEnum
{
    [StringValue(null)]
    NullValue,
    
    [StringValue("")]
    EmptyValue
}

Console.WriteLine(TestEnum.NullValue.GetStringValue()); 
// Output: null

Console.WriteLine(TestEnum.EmptyValue.GetStringValue()); 
// Output: (empty string)
```

## Next Steps

- [Advanced Usage](./advanced-usage.md) - Learn how to create custom attributes
- [API Reference](./api-reference.md) - Detailed documentation of all classes and methods
