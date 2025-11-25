# Architecture Overview

> **Commit Reference:** `05e796ffe1bfb23188eed5ccb7b5222709f0455f` (v0.0.1)

This document describes the architecture and design of the MbSoftLab.StringEnums library.

## Project Structure

```
MbSoftLab.StringEnums/
├── MbSoftLab.StringEnums/           # Main library
│   ├── StringValueAttribute.cs      # Base attribute for string values
│   ├── ConditionalStringValueAttribute.cs  # Conditional attribute
│   ├── EnumExtensions.cs            # Extension methods
│   └── MbSoftLab.StringEnums.csproj # Project file
├── MbSoftLab.StringEnums.Demo/      # Demo application
│   ├── Program.cs                   # Example usage
│   └── MbSoftLab.StringEnums.Demo.csproj
├── MbSoftLab.StringEnums.Test/      # Unit tests
│   ├── EnumExtensionsUnitTest.cs    # Test cases
│   ├── DummyData/                   # Test data
│   └── MbSoftLab.StringEnums.Test.csproj
└── MbSoftLab.StringEnums.sln        # Solution file
```

## Class Diagram

```mermaid
classDiagram
    class Attribute {
        <<abstract>>
    }
    
    class StringValueAttribute {
        -string _value
        +string Value
        +StringValueAttribute(string value)
    }
    
    class ConditionalStringValueAttribute {
        -string _valueTrue
        -string _valueFalse
        +string ValueTrue
        +string ValueFalse
        +ConditionalStringValueAttribute(string valueTrue, string valueFalse)
    }
    
    class StringEnumExtensions {
        <<static>>
        +GetStringValue(Enum value)$ string
        +GetStringValueByCondition(Enum value, bool condition)$ string
        +GetAttributesFromEnum~TAttribute~(Enum value)$ TAttribute[]
        +GetValueFromAttribute~TAttribute~(Enum value)$ string
    }
    
    Attribute <|-- StringValueAttribute
    Attribute <|-- ConditionalStringValueAttribute
    StringEnumExtensions ..> StringValueAttribute : uses
    StringEnumExtensions ..> ConditionalStringValueAttribute : uses
```

## Component Overview

```mermaid
graph TB
    subgraph "MbSoftLab.StringEnums Library"
        SVA[StringValueAttribute]
        CSVA[ConditionalStringValueAttribute]
        EXT[StringEnumExtensions]
    end
    
    subgraph "User Code"
        ENUM[User Enum]
        CUSTOM[Custom Attributes]
        CODE[Application Code]
    end
    
    ENUM -- decorated with --> SVA
    ENUM -- decorated with --> CSVA
    CUSTOM -- extends --> SVA
    CUSTOM -- extends --> CSVA
    CODE -- uses --> EXT
    EXT -- reads --> SVA
    EXT -- reads --> CSVA
```

## How It Works

### Sequence Diagram: GetStringValue

```mermaid
sequenceDiagram
    participant App as Application Code
    participant Ext as StringEnumExtensions
    participant Ref as System.Reflection
    participant Attr as StringValueAttribute
    
    App->>Ext: enumValue.GetStringValue()
    Ext->>Ext: GetAttributesFromEnum<StringValueAttribute>(value)
    Ext->>Ref: GetType()
    Ref-->>Ext: Type
    Ext->>Ref: GetField(value.ToString())
    Ref-->>Ext: FieldInfo
    Ext->>Ref: GetCustomAttributes(typeof(T), false)
    Ref-->>Ext: StringValueAttribute[]
    alt Has Attribute
        Ext->>Attr: .Value
        Attr-->>Ext: string value
        Ext-->>App: "string value"
    else No Attribute
        Ext-->>App: ""
    end
```

### Sequence Diagram: Custom Attribute

```mermaid
sequenceDiagram
    participant App as Application Code
    participant CustomExt as Custom Extension
    participant Ext as StringEnumExtensions
    participant Attr as Custom Attribute
    
    App->>CustomExt: enumValue.GetCssClass()
    CustomExt->>Ext: GetValueFromAttribute<CssClassAttribute>(value)
    Ext->>Ext: GetAttributesFromEnum<CssClassAttribute>(value)
    Ext-->>CustomExt: CssClassAttribute[]
    alt Has Attribute
        CustomExt-->>App: "css-class-value"
    else No Attribute
        CustomExt-->>App: null
    end
```

## Extensibility Model

```mermaid
graph LR
    subgraph "Base Classes"
        SVA[StringValueAttribute]
        CSVA[ConditionalStringValueAttribute]
    end
    
    subgraph "Custom Implementations"
        CSS[CssClassAttribute]
        API[ApiValueAttribute]
        LOC[LocalizationKeyAttribute]
        DB[DbValueAttribute]
    end
    
    SVA --> CSS
    SVA --> API
    SVA --> LOC
    SVA --> DB
```

## Design Principles

### 1. Simplicity
The library follows the principle of doing one thing well: associating string values with enum members.

### 2. Extensibility
By providing a base `StringValueAttribute` class, users can easily create their own domain-specific attributes.

### 3. Non-Invasive
The library uses extension methods, which means no changes are required to existing enum types.

### 4. Lightweight
- No external dependencies
- Targets .NET Standard 2.0 for maximum compatibility
- Small binary footprint

### 5. Type Safety
Uses generics to ensure type safety when working with custom attributes.

## Data Flow

```mermaid
flowchart LR
    A[Enum Member] --> B{Has Attribute?}
    B -->|Yes| C[Get Attribute Value]
    B -->|No| D[Return Empty/Null]
    C --> E[Return String Value]
```

## Dependencies

The library has minimal dependencies:

| Dependency | Purpose |
|------------|---------|
| System | Core functionality |
| System.Reflection | Reading attributes from enum members |

## Build Configuration

| Property | Value |
|----------|-------|
| Target Framework | netstandard2.0 |
| Version | 0.0.1 |
| License | MIT |
| Package Generation | On Build |

## See Also

- [Quick Start Guide](../quickstart.md)
- [API Reference](../api-reference.md)
- [Advanced Usage](../advanced-usage.md)
