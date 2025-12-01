# Installation Guide

> **Commit Reference:** `be2d13051e07c898966cbbee29172b9941101de5` (v1.0.2)

## Package Information

| Property | Value |
|----------|-------|
| Package Name | MbSoftLab.StringEnums |
| Current Version | 1.0.2 |
| License | MIT |
| Target Framework | .NET Standard 2.0 |

## Installation Methods

### NuGet Package Manager

```powershell
Install-Package MbSoftLab.StringEnums
```

### .NET CLI

```bash
dotnet add package MbSoftLab.StringEnums
```

### Package Reference

Add the following to your `.csproj` file:

```xml
<PackageReference Include="MbSoftLab.StringEnums" Version="1.0.2" />
```

## Namespace

After installation, add the following using directive to your code files:

```csharp
using MbSoftLab.StringEnums;
```

## Verification

To verify the installation, create a simple enum with a string value:

```csharp
using MbSoftLab.StringEnums;

public enum TestEnum
{
    [StringValue("test-value")]
    Test
}

// This should output "test-value"
Console.WriteLine(TestEnum.Test.GetStringValue());
```

## Next Steps

- [Quick Start Guide](./quickstart.md) - Learn the basics of using the library
- [API Reference](./api-reference.md) - Detailed documentation of all classes and methods
