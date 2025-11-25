# MbSoftLab.StringEnums

[![CodeFactor](https://www.codefactor.io/repository/github/mbsoftlab/mbsoftlab.stringenums/badge)](https://www.codefactor.io/repository/github/mbsoftlab/mbsoftlab.stringenums)
[![Release](https://github.com/mbsoftlab/MbSoftLab.StringEnums/actions/workflows/Release.yml/badge.svg?branch=master)](https://github.com/mbsoftlab/MbSoftLab.StringEnums/actions/workflows/Release.yml)
[![BuildFromMaster](https://github.com/mbsoftlab/MbSoftLab.StringEnums/actions/workflows/BuildFromMaster.yml/badge.svg?branch=master)](https://github.com/mbsoftlab/MbSoftLab.StringEnums/actions/workflows/BuildFromMaster.yml)
[![NuGet](https://img.shields.io/nuget/v/MbSoftLab.StringEnums.svg)](https://www.nuget.org/packages/MbSoftLab.StringEnums)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Description

**MbSoftLab.StringEnums** is a lightweight .NET library that allows you to decorate enum members with custom string values. Perfect for associating enums with display names, CSS classes, API values, or any other string representation.

### Features

- 🏷️ **Simple String Values** - Attach string values using `[StringValue]` attribute
- 🔄 **Conditional Values** - Return different strings based on conditions with `[ConditionalStringValue]`
- 🔧 **Extensible** - Create your own custom attributes
- 📦 **Lightweight** - No external dependencies, targets .NET Standard 2.0

---

## Installation

```bash
dotnet add package MbSoftLab.StringEnums
```

Or via NuGet Package Manager:
```powershell
Install-Package MbSoftLab.StringEnums
```

---

## Quick Start

### **Simple StringValues for Enums**
```csharp
 
// The enum 
 public enum MyEnum
 { 
   [StringValue("my-css-class-1")]
   Class1,

   [StringValue("my-css-class-2")]
   Class2
 }

Console.WriteLine(MyEnum.Class1.GetStringValue()); // output: my-css-class-1
Console.WriteLine(MyEnum.Class2.GetStringValue()); // output: my-css-class-2

```

---

### **Custom StringValue Attributes**
 
```csharp
using System;

namespace MbSoftLab.StringEnums.Demo
{
    public class CssClassAttribute : StringValueAttribute
    {
        public CssClassAttribute(string value) : base(value) { }
    }

    public static class CssClassEnumExtension
    {
        // Your concrete EnumExtension
        public static string GetCssClass(this Enum value)
        {
            return value.GetValueFromAttribute<CssClassAttribute>();
        }
    }
    // The enum 
    public enum MyEnum
    {
        [StringValue("i am a string")]
        [CssClass("my-css-class-1")]
        Class1,

        [CssClass("my-css-class-2")]
        Class2
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyEnum.Class1.GetStringValue()); // output: i am a string
            Console.WriteLine(MyEnum.Class1.GetCssClass()); // output: my-css-class-1
            Console.WriteLine(MyEnum.Class2.GetCssClass()); // output: my-css-class-2

            Console.ReadKey();
        }
    }
}


```

---

### **Conditional String Values**

Return different strings based on a boolean condition:

```csharp
public enum ToggleState
{
    [ConditionalStringValue("enabled", "disabled")]
    Power
}

// Usage
Console.WriteLine(ToggleState.Power.GetStringValueByCondition(true));  // output: enabled
Console.WriteLine(ToggleState.Power.GetStringValueByCondition(false)); // output: disabled
```

---

## Documentation

For detailed documentation, see:

- 📖 [Full Documentation](./docs/README.md)
- 🚀 [Quick Start Guide](./docs/quickstart.md)
- 📚 [API Reference](./docs/api-reference.md)
- 🔧 [Advanced Usage](./docs/advanced-usage.md)
- 🏗️ [Architecture](./docs/architecture/README.md)
- 📝 [Changelog](./CHANGELOG.md)
- 🎉 [Release Notes](./RELEASENOTES.md)

---

## Compatibility

| Target Framework | Supported |
|------------------|-----------|
| .NET Standard 2.0 | ✅ |
| .NET Core 2.0+ | ✅ |
| .NET 5.0+ | ✅ |
| .NET Framework 4.6.1+ | ✅ |

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
