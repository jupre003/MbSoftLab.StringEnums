# Advanced Usage

> **Commit Reference:** `05e796ffe1bfb23188eed5ccb7b5222709f0455f` (v0.0.1)

This guide covers advanced usage scenarios for MbSoftLab.StringEnums, including creating custom attributes and extension methods.

## Creating Custom Attributes

The library is designed to be extensible. You can create your own custom attributes by inheriting from `StringValueAttribute` or `ConditionalStringValueAttribute`.

### Custom String Value Attribute

Create a domain-specific attribute for your use case:

```csharp
using System;
using MbSoftLab.StringEnums;

namespace MyApplication
{
    /// <summary>
    /// Custom attribute for CSS class names
    /// </summary>
    public class CssClassAttribute : StringValueAttribute
    {
        public CssClassAttribute(string value) : base(value) { }
    }
}
```

### Creating the Extension Method

Create a corresponding extension method to retrieve the value:

```csharp
using System;
using MbSoftLab.StringEnums;

namespace MyApplication
{
    public static class CssClassEnumExtension
    {
        /// <summary>
        /// Gets the CSS class name associated with the enum member
        /// </summary>
        public static string GetCssClass(this Enum value)
        {
            return value.GetValueFromAttribute<CssClassAttribute>();
        }
    }
}
```

### Using the Custom Attribute

Apply the custom attribute to your enums:

```csharp
public enum ButtonType
{
    [CssClass("btn btn-primary")]
    Primary,

    [CssClass("btn btn-secondary")]
    Secondary,

    [CssClass("btn btn-danger")]
    Danger,

    [CssClass("btn btn-success")]
    Success
}

// Usage
string cssClass = ButtonType.Primary.GetCssClass(); // "btn btn-primary"
```

## Multiple Custom Attributes

You can apply multiple attributes to the same enum member:

```csharp
// Define multiple custom attributes
public class DisplayNameAttribute : StringValueAttribute
{
    public DisplayNameAttribute(string value) : base(value) { }
}

public class IconAttribute : StringValueAttribute
{
    public IconAttribute(string value) : base(value) { }
}

public class CssClassAttribute : StringValueAttribute
{
    public CssClassAttribute(string value) : base(value) { }
}

// Extension methods
public static class UIEnumExtensions
{
    public static string GetDisplayName(this Enum value)
        => value.GetValueFromAttribute<DisplayNameAttribute>();

    public static string GetIcon(this Enum value)
        => value.GetValueFromAttribute<IconAttribute>();

    public static string GetCssClass(this Enum value)
        => value.GetValueFromAttribute<CssClassAttribute>();
}

// Enum with multiple attributes
public enum NotificationType
{
    [DisplayName("Success")]
    [Icon("check-circle")]
    [CssClass("alert alert-success")]
    Success,

    [DisplayName("Warning")]
    [Icon("exclamation-triangle")]
    [CssClass("alert alert-warning")]
    Warning,

    [DisplayName("Error")]
    [Icon("times-circle")]
    [CssClass("alert alert-danger")]
    Error,

    [DisplayName("Information")]
    [Icon("info-circle")]
    [CssClass("alert alert-info")]
    Info
}

// Usage
var notification = NotificationType.Success;
Console.WriteLine(notification.GetDisplayName()); // "Success"
Console.WriteLine(notification.GetIcon());        // "check-circle"
Console.WriteLine(notification.GetCssClass());    // "alert alert-success"
```

## Custom Conditional Attributes

You can also extend `ConditionalStringValueAttribute`:

```csharp
public class VisibilityAttribute : ConditionalStringValueAttribute
{
    public VisibilityAttribute(string visibleClass, string hiddenClass) 
        : base(visibleClass, hiddenClass) { }
}
```

## Combining with Standard Attributes

The library's attributes work alongside the standard `[StringValue]` attribute:

```csharp
public enum MyEnum
{
    [StringValue("i am a string")]
    [CssClass("my-css-class-1")]
    Class1,

    [CssClass("my-css-class-2")]
    Class2
}

// Usage
Console.WriteLine(MyEnum.Class1.GetStringValue()); // "i am a string"
Console.WriteLine(MyEnum.Class1.GetCssClass());    // "my-css-class-1"
Console.WriteLine(MyEnum.Class2.GetCssClass());    // "my-css-class-2"
```

## Real-World Use Cases

### API Value Mapping

Map enum values to API strings:

```csharp
public class ApiValueAttribute : StringValueAttribute
{
    public ApiValueAttribute(string value) : base(value) { }
}

public static class ApiExtensions
{
    public static string ToApiValue(this Enum value)
        => value.GetValueFromAttribute<ApiValueAttribute>();
}

public enum OrderStatus
{
    [ApiValue("pending_payment")]
    PendingPayment,

    [ApiValue("processing")]
    Processing,

    [ApiValue("shipped")]
    Shipped,

    [ApiValue("delivered")]
    Delivered,

    [ApiValue("cancelled")]
    Cancelled
}

// Usage in API calls
var status = OrderStatus.PendingPayment;
var apiValue = status.ToApiValue(); // "pending_payment"
```

### Database Value Mapping

Map enum values to database strings:

```csharp
public class DbValueAttribute : StringValueAttribute
{
    public DbValueAttribute(string value) : base(value) { }
}

public static class DatabaseExtensions
{
    public static string ToDbValue(this Enum value)
        => value.GetValueFromAttribute<DbValueAttribute>();
}

public enum UserRole
{
    [DbValue("ADMIN")]
    Administrator,

    [DbValue("MOD")]
    Moderator,

    [DbValue("USR")]
    User,

    [DbValue("GUEST")]
    Guest
}
```

### Localization Keys

Use with localization:

```csharp
public class LocalizationKeyAttribute : StringValueAttribute
{
    public LocalizationKeyAttribute(string value) : base(value) { }
}

public static class LocalizationExtensions
{
    public static string GetLocalizationKey(this Enum value)
        => value.GetValueFromAttribute<LocalizationKeyAttribute>();
}

public enum ErrorCode
{
    [LocalizationKey("error.validation.required")]
    RequiredFieldMissing,

    [LocalizationKey("error.validation.format")]
    InvalidFormat,

    [LocalizationKey("error.auth.unauthorized")]
    Unauthorized
}
```

## Best Practices

1. **Keep attribute classes simple**: Only override the constructor, inherit all functionality from the base class.

2. **Use descriptive names**: Name your custom attributes clearly (e.g., `CssClassAttribute`, `ApiValueAttribute`).

3. **Create corresponding extension methods**: Always create an extension method for each custom attribute for easy access.

4. **Handle null values**: The `GetValueFromAttribute<T>()` method returns `null` if the attribute is not found. Handle this in your code if needed.

5. **Document your custom attributes**: Add XML documentation to help other developers understand the purpose of each attribute.

## See Also

- [Quick Start Guide](./quickstart.md)
- [API Reference](./api-reference.md)
- [Architecture](./architecture/README.md)
