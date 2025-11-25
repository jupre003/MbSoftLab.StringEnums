# MbSoftLab.StringEnums Documentation

> **Commit Reference:** `05e796ffe1bfb23188eed5ccb7b5222709f0455f` (v0.0.1)

## Overview

**MbSoftLab.StringEnums** is a lightweight .NET library that allows you to decorate enum members with custom string values. This is particularly useful when you need to associate enums with display names, CSS classes, API values, or any other string representation.

## Table of Contents

1. [Installation](./installation.md)
2. [Quick Start](./quickstart.md)
3. [API Reference](./api-reference.md)
4. [Advanced Usage](./advanced-usage.md)
5. [Architecture](./architecture/README.md)

## Features

- **Simple String Values**: Attach string values to enum members using the `[StringValue]` attribute
- **Conditional String Values**: Return different strings based on a boolean condition using `[ConditionalStringValue]`
- **Custom Attributes**: Create your own custom string value attributes by extending `StringValueAttribute`
- **Extension Methods**: Easy-to-use extension methods for retrieving string values from enums
- **Lightweight**: No external dependencies, targets .NET Standard 2.0 for maximum compatibility

## Quick Example

```csharp
using MbSoftLab.StringEnums;

public enum Status
{
    [StringValue("active")]
    Active,
    
    [StringValue("inactive")]
    Inactive,
    
    [ConditionalStringValue("enabled", "disabled")]
    Toggleable
}

// Usage
Console.WriteLine(Status.Active.GetStringValue());        // Output: active
Console.WriteLine(Status.Inactive.GetStringValue());      // Output: inactive
Console.WriteLine(Status.Toggleable.GetStringValueByCondition(true));   // Output: enabled
Console.WriteLine(Status.Toggleable.GetStringValueByCondition(false));  // Output: disabled
```

## Compatibility

| Target Framework | Supported |
|------------------|-----------|
| .NET Standard 2.0 | ✅ |
| .NET Core 2.0+ | ✅ |
| .NET 5.0+ | ✅ |
| .NET Framework 4.6.1+ | ✅ |

## License

This library is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.

## Links

- [NuGet Package](https://www.nuget.org/packages/MbSoftLab.StringEnums)
- [GitHub Repository](https://github.com/mbsoftlab/MbSoftLab.StringEnums)
