# Release Notes

## Version 1.0.2 (November 28, 2025)

### Übersicht

Version 1.0.2 bringt eine signifikante Verbesserung der Codequalität durch 100% Testabdeckung.

### Änderungen

#### Tests
- **100% Testabdeckung** aller Kernkomponenten
- Neue Testdateien:
  - `ConditionalStringValueAttributeTests.cs` - Tests für bedingte String-Werte
  - `CustomStringValueExtensionsTests.cs` - Tests für benutzerdefinierte Erweiterungen
  - `StringEnumExtensionsTests.cs` - Umfassende Tests für Extension-Methoden
  - `StringValueAttributeTests.cs` - Tests für das StringValue-Attribut

#### Testdaten
- Neue Testhelfer in `DummyData/`:
  - `CustomConditionalStringValueAttribute.cs`
  - `CustomStringValueAttribute.cs`
  - `CustomStringValueExtensions.cs`

### Commit-Referenz

- `be2d130` - Increase test coverage to 100% and update to version 1.0.2

### Installation

```bash
dotnet add package MbSoftLab.StringEnums --version 1.0.2
```

Oder über NuGet Package Manager:
```powershell
Install-Package MbSoftLab.StringEnums -Version 1.0.2
```

---

## Version 0.0.1 (May 2, 2021)

### Overview

This is the initial release of MbSoftLab.StringEnums, a lightweight .NET library for decorating enum members with custom string values.

### Features

#### Core Attributes
- **StringValueAttribute**: Attach a simple string value to any enum member
- **ConditionalStringValueAttribute**: Associate two string values with an enum member, selecting one based on a boolean condition

#### Extension Methods
- **GetStringValue()**: Retrieve the string value from an enum member
- **GetStringValueByCondition(bool)**: Get conditional string values
- **GetAttributesFromEnum<T>()**: Access raw attributes for advanced scenarios
- **GetValueFromAttribute<T>()**: Retrieve values from custom attributes

#### Extensibility
- Create custom attributes by extending `StringValueAttribute`
- Support for multiple attributes on a single enum member

### Platform Support

| Platform | Version |
|----------|---------|
| .NET Standard | 2.0 |
| .NET Core | 2.0+ |
| .NET | 5.0+ |
| .NET Framework | 4.6.1+ |

### Installation

```bash
dotnet add package MbSoftLab.StringEnums --version 0.0.1
```

Or via NuGet Package Manager:
```powershell
Install-Package MbSoftLab.StringEnums -Version 0.0.1
```

### Quick Example

```csharp
using MbSoftLab.StringEnums;

public enum Priority
{
    [StringValue("low-priority")]
    Low,
    
    [StringValue("high-priority")]
    High
}

// Usage
Console.WriteLine(Priority.Low.GetStringValue());  // Output: low-priority
Console.WriteLine(Priority.High.GetStringValue()); // Output: high-priority
```

### Known Limitations

- This is the first release; future versions may include additional features
- Enum members without attributes return empty string or null

### License

MIT License

### Links

- [GitHub Repository](https://github.com/mbsoftlab/MbSoftLab.StringEnums)
- [NuGet Package](https://www.nuget.org/packages/MbSoftLab.StringEnums)
- [Documentation](./docs/README.md)
