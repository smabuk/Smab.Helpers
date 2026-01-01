# Smab.Helpers.IParsableSourceGenerator

A small Roslyn source-generator project that provides automatic implementations of `IParsable<T>` for types in consumer projects.

## Purpose

This project contains a source generator that inspects consumer code at compile time and emits parsing-related boilerplate so types can implement `System.IParsable<T>` (or compatible parsing helpers) without manual parsing logic.

## Project details

- Target framework: `netstandard2.0` (built as a Roslyn component so it can be referenced as an analyzer/source-generator)
- Language version: `latest` (project-level setting)
- Project type: Source generator (`IsRoslynComponent` = true)
- Notable package dependencies:
  - `Microsoft.CodeAnalysis.CSharp` (Roslyn APIs)
  - `Microsoft.CodeAnalysis.Analyzers`

## Files of interest

- `ParsableGenerator.cs` - main source-generator implementation (generates code to wire up parsing implementations).
- `Smab.Helpers.IParsableSourceGenerator.csproj` - project configuration and packaging metadata.

## Usage

1. Add the NuGet package (when published) or reference the analyzer project from a consuming solution as an analyzer.
2. Implement a partial type or marker pattern expected by the generator (see `ParsableGenerator.cs` for concrete shape expected by the generator).
3. Build the consuming project. The generator will emit the parsing implementation at compile time.

Note: Because this project targets `netstandard2.0` and is marked as a Roslyn component, it is intended to be consumed as an analyzer/source-generator and not referenced as a runtime library.

## GenerateIParsable attribute

The generator provides a `GenerateIParsableAttribute` that you place on a type to request generation of `IParsable<T>`-style parsing helpers. The attribute is generated into the compilation by the source generator, so you do not need to add any additional packages to make the attribute available.

Key attribute properties:

- `SplitChars` (string): characters used for simple splitting of input when a type has multiple constructor parameters. Default: " ," (space and comma).
- `SplitPattern` (string?): optional regular expression used to split input. If set, it takes precedence over `SplitChars`.
- `RemoveEmptyEntries` (bool): whether to remove empty entries after splitting. Default: `true`.
- `CapturePattern` (string?): optional regex with named capture groups. When provided, the generator will use named groups (matching constructor parameter names) to parse complex inputs. This takes precedence over splitting.

Because the attribute is added by the generator into the `Smab.Helpers.IParsableSourceGenerator` namespace, you can reference it either with a `using` or fully-qualified name.

Example declarations:

```csharp
using Smab.Helpers.IParsableSourceGenerator;

[GenerateIParsable]
public partial record MyNumber(int Value);
```

or fully-qualified:

```csharp
[Smab.Helpers.IParsableSourceGenerator.GenerateIParsable]
public partial record MyNumber(int Value);
```

## Attribute usage examples

- Simple single-value type

```csharp
using Smab.Helpers.IParsableSourceGenerator;

[GenerateIParsable]
public partial record MyNumber(int Value);

// Usage after generation
MyNumber x = MyNumber.Parse("42");
```

- Multi-parameter record using simple splitting

```csharp
using Smab.Helpers.IParsableSourceGenerator;

[GenerateIParsable(SplitChars = " ,", RemoveEmptyEntries = true)]
public partial record Point(int X, int Y);

// Parses strings like "10,20" or "10 20"
Point p = Point.Parse("10,20");
```

- Multi-parameter record using a capture regex (named groups must match constructor parameter names)

```csharp
using Smab.Helpers.IParsableSourceGenerator;

[GenerateIParsable(CapturePattern = @"(?<X>-?\d+):(?<Y>-?\d+)")]
public partial record Point(int X, int Y);

// Parses strings like "10:20"
Point p = Point.Parse("10:20");
```

- Generic type parameter (requires generic parameter to be constrained to `IParsable<T>` so the generator can call `T.Parse`)

```csharp
using Smab.Helpers.IParsableSourceGenerator;

[GenerateIParsable]
public partial record Wrapper<T>(T Value) where T : IParsable<T>;

// Usage where T implements IParsable<T>
var w = Wrapper<int>.Parse("123");
```

- Collection parameter example (generator will split and parse elements)

```csharp
using Smab.Helpers.IParsableSourceGenerator;

[GenerateIParsable(SplitChars = ",")] // split on commas
public partial record IdList(List<int> Ids);

// Parses "1,2,3" into a List<int>
var list = IdList.Parse("1,2,3");
```

## Examples

The following examples show common ways to reference the generator and the shape of types the generator can target. Refer to `ParsableGenerator.cs` for the exact expectations used by this generator.

### Add the generator to a consuming project

Add the package as an analyzer dependency (package name shown as example):

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Smab.Helpers.IParsableSourceGenerator" Version="1.0.0" PrivateAssets="all" />
  </ItemGroup>
</Project>
```

The `PrivateAssets="all"` prevents the analyzer package from flowing to consumers of your library.

### Example consumer type

Create a simple partial type that represents the value you want parsed. The generator will detect types following the expected pattern and emit `IParsable<T>` implementations.

```csharp
// In consuming project
public partial record MyNumber(int Value);
```

### Example of generated code (illustrative)

When the generator runs it will emit code similar to the following (actual generated code may vary):

```csharp
// Generated by Smab.Helpers.IParsableSourceGenerator
public partial record MyNumber : System.IParsable<MyNumber>
{
    public static MyNumber Parse(string s, IFormatProvider? provider)
    {
        if (TryParse(s, provider, out var result))
            return result;

        throw new FormatException($"Unable to parse '{s}' as MyNumber.");
    }

    public static bool TryParse(string s, IFormatProvider? provider, out MyNumber result)
    {
        if (int.TryParse(s, System.Globalization.NumberStyles.Integer, provider, out var v))
        {
            result = new MyNumber(v);
            return true;
        }

        result = default!;
        return false;
    }
}
```

This generated implementation delegates to underlying primitive parsers (for example `int.TryParse`) and wraps results into the target type.

## Build & Test

- Build the repository from the solution root:

  ```bash
  dotnet build
  ```

- Run tests from the solution root:

  ```bash
  dotnet test
  ```

- Create a NuGet package (pack) from the project directory:

  ```bash
  dotnet pack -c Release
  ```

## Contributing

See the root repository CONTRIBUTING guidelines. Keep changes small and focused. When modifying generator behavior, add unit tests in `Smab.Helpers.Tests` to cover generated outputs where possible.

## License

This project is licensed under the MIT License. See the top-level `LICENSE` file for details.
