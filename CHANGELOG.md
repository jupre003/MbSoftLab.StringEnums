# Changelog

All notable changes to the MbSoftLab.StringEnums project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.2] - 2025-11-28

### Changed
- Erhöhung der Testabdeckung auf 100%
- Aktualisierung auf Version 1.0.2

### Added
- Neue Unit-Tests für umfassende Testabdeckung:
  - `ConditionalStringValueAttributeTests.cs`
  - `CustomStringValueExtensionsTests.cs`
  - `StringEnumExtensionsTests.cs`
  - `StringValueAttributeTests.cs`
- Erweiterte Testdaten in `DummyData/`:
  - `CustomConditionalStringValueAttribute.cs`
  - `CustomStringValueAttribute.cs`
  - `CustomStringValueExtensions.cs`

### Commit Reference
- `be2d130` - Increase test coverage to 100% and update to version 1.0.2

---

## [0.0.1] - 2021-05-02

### Added
- Initial release of MbSoftLab.StringEnums
- `StringValueAttribute` - Base attribute for associating string values with enum members
- `ConditionalStringValueAttribute` - Attribute for conditional string values based on boolean conditions
- `StringEnumExtensions` class with extension methods:
  - `GetStringValue()` - Retrieve string value from enum member
  - `GetStringValueByCondition(bool condition)` - Retrieve conditional string value
  - `GetAttributesFromEnum<TAttribute>()` - Get all attributes of a type from enum member
  - `GetValueFromAttribute<TAttribute>()` - Get value from custom attribute
- Support for creating custom attributes by extending `StringValueAttribute`
- .NET Standard 2.0 targeting for maximum compatibility
- MIT License
- NuGet package generation on build

### Commit History
- `05e796f` - v0.0.1 (Release)
- `8be6bc0` - Updated Readme & Readded PackageIcon
- `f1e9f4d` - Removed PackageIcon
- `bd4cccc` - Update Package Setup
- `590338b` - Replaced obsolete Tag "PackageIconUrl" with PackageIcon
- `d9beeed` - UsingPackageIconUrl for PackageLogo
- `b336ee0` - Using PackageIconUrl for PackageIcon
- `fa91e56` - Moved package logo
- `0dc0b03` - v0.0.1-preview2 (Setup CI/CD)
- `0f3336b` - Update package infos
- `cabe176` - Setup Ci/Cd
- `c81b8ff` - Add Ci / Cd workflows
- `4f8118f` - Add Ci / Cd workflows
- `77a4155` - Added project files
- `a7eaac9` - Initial commit (GITIGNORE and GITATTRIBUTES)

---

[1.0.2]: https://github.com/mbsoftlab/MbSoftLab.StringEnums/releases/tag/v1.0.2
[0.0.1]: https://github.com/mbsoftlab/MbSoftLab.StringEnums/releases/tag/v0.0.1
