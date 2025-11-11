# Smab.Helpers

[![NuGet](https://img.shields.io/nuget/v/Smab.Helpers.svg)](https://www.nuget.org/packages/Smab.Helpers/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A comprehensive C# helper library targeted at Advent of Code providing utilities for grid/matrix operations, parsing, mathematics, algorithms, JSON serialization, and more. Designed for .NET 10.0 with modern C# features.

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Smab.Helpers
```

Or via Package Manager Console:

```powershell
Install-Package Smab.Helpers
```

## Features

Smab.Helpers provides a rich set of extension methods and utilities organized into the following categories:

### 📐 Grid & Spatial Helpers
- **Point & Point3d**: Robust 2D and 3D point structures with operator overloading
- **Direction & HexDirection**: Enums for cardinal, intercardinal, and hexagonal directions
- **Cell & Cube**: Grid cell representations
- **Grid Operations**: Transpose, rotate, flip, fill, adjacency detection
- **Pathfinding**: Dijkstra's algorithm implementation
- **Coordinate Systems**: Hexagonal coordinate support

### 🔢 Parsing Helpers
- Parse strings to numbers, points, cells, enums
- Binary/hex/octal conversions
- Split and trim utilities
- Digit extraction
- Regex-based parsing helpers

### 🧮 Mathematics Helpers
- Statistical operations: Mean, median, mode, min/max
- Number range operations and overlap detection
- Linear equation solver
- LCM (Least Common Multiple) calculation
- Base conversions
- Number validation and range checking

### 🔄 Algorithmic Helpers
- Dijkstra's shortest path algorithm
- Permutations and combinations
- Binary search (binary chop)
- Manhattan distance calculation
- Sequence helpers

### 🗂️ LINQ Extensions
- `ForEach`: Execute actions on collections
- `IsIn`: Check membership
- `NotWhere`: Inverse filtering
- `DoesNotContain`: Inverse contains check

### 📅 DateTime Extensions
- Additional date/time manipulation utilities

### 📦 JSON Helpers
- `JsonDateOnlyConverter`: Serialize/deserialize `DateOnly` in `yyyy-MM-dd` format
- `JsonTimeOnlyConverter`: Serialize/deserialize `TimeOnly` in `HH:mm:ss` format
- `JsonUnixDateConverter`: Unix timestamp conversion

### 🎨 UTF-16 Character Collections
Extensive Unicode character sets for console/terminal applications:
- Box drawing characters
- Block elements
- Geometric shapes
- Mathematical symbols (A & B sets)
- Arrows (standard and supplemental A & B)
- Braille patterns
- Dingbats
- Musical symbols
- Hebrew characters
- And more!

### 🌐 HTML Helpers
- `HasClass`: Check for CSS class presence in HTML elements

### 🎯 Advent of Code Helpers
- OCR helpers for recognizing ASCII art letters

## Usage Examples

### Grid & Point Operations

```csharp
using Smab.Helpers;

// Create and manipulate points
var p1 = new Point(5, 10);
var p2 = new Point(3, 4);
var sum = p1 + p2;              // (8, 14)
var diff = p1 - p2;             // (2, 6)
var scaled = p1 * 2;            // (10, 20)

// Predefined points
var origin = Point.Zero;         // (0, 0)
var unit = Point.One;            // (1, 1)
var unitX = Point.UnitX;         // (1, 0)

// 3D points
var p3d = new Point3d(1, 2, 3);

// Directions
var direction = Direction.North | Direction.East; // NorthEast
var hexDir = HexDirection.NE;
```

### Grid/Array Operations

```csharp
// Create a 2D array
int[,] grid = new int[5, 5];

// Fill with a value
grid.Fill(0);

// Get adjacent cells (4-directional)
var adjacent = grid.GetAdjacentCells(new Point(2, 2));

// Get adjacent cells (8-directional including diagonals)
var adjacentWithDiagonals = grid.GetAdjacentCells(new Point(2, 2), includeDiagonals: true);

// Transpose a grid
var transposed = grid.Transpose();

// Rotate 90 degrees
var rotated = grid.RotateRight();

// Flip horizontally or vertically
var flipped = grid.FlipHorizontally();

// Convert to string array
string[] rows = grid.AsStrings();
```

### Parsing Helpers

```csharp
using Smab.Helpers;

// Parse numbers from delimited string
string input = "1, 2, 3, 4, 5";
IEnumerable<int> numbers = input.AsNumbers<int>();
// or
var ints = input.AsInts();
var longs = input.AsLongs();

// Parse to specific type
int value = "42".As<int>();
double pi = "3.14159".As<double>();

// Parse enum
var myEnum = "Value1".AsEnum<MyEnum>();

// Parse points
var point = "(5, 10)".As<Point>();

// Extract digits from string
string text = "abc123def456";
var digits = text.AsDigits(); // "123456"

// Split and trim
string csv = " a , b , c ";
var parts = csv.TrimmedSplit(','); // ["a", "b", "c"]

// Binary conversions
string binary = "FF".AsBinaryFromHex();    // "11111111"
string fromOctal = "17".AsBinaryFromOctal(); // "1111"
int fromBinary = "1010".FromBinaryAs<int>(); // 10
```

### Mathematical Operations

```csharp
using Smab.Helpers;

// Statistical operations
var numbers = new[] { 1, 2, 3, 4, 5 };
var mean = numbers.Mean();       // 3.0
var median = numbers.Median();   // 3
var modes = numbers.Modes();     // Most frequent values

// Min/Max
var (min, max) = numbers.MinMax();

// Check if number is in range
bool inRange = 5.IsInRange(1, 10);        // true
bool inRangeEx = 5.IsInRange(1, 5, true); // false (exclusive end)

// Range overlap
var (overlapStart, overlapEnd) = (1, 10).GetOverlap((5, 15)); // (5, 10)

// Solve linear equations: ax + by = c
bool solved = MathsHelpers.TrySolveLinearEquations(
    ax: 2, bx: 3, cx: 12,
    ay: 4, by: 1, cy: 11,
    out var result);
// result.A and result.B contain the solution

// LCM (Least Common Multiple)
long lcm = MathsHelpers.LCM(12, 18); // 36

// Base conversions
string binary = 42.ToBinaryAsString();      // "101010"
string hex = 255.ToBaseAsString(16);        // "ff"
```

### Algorithmic Helpers

```csharp
using Smab.Helpers;

// Dijkstra's shortest path
int[,] grid = LoadGrid();
var costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(
    grid,
    start: new Point(0, 0),
    end: new Point(9, 9)
);

// Manhattan distance
int distance = AlgorithmicHelpers.ManhattanDistance(
    new Point(0, 0),
    new Point(3, 4)
); // 7

// Permutations
var items = new[] { 1, 2, 3 };
var permutations = items.Permute();

// Combinations
var combinations = items.Combinations(2);

// Binary search
var sortedList = new List<int> { 1, 3, 5, 7, 9 };
int index = sortedList.BinaryChop(5); // 2
```

### LINQ Extensions

```csharp
using Smab.Helpers;

// ForEach extension
var numbers = new[] { 1, 2, 3, 4, 5 };
numbers.ForEach(n => Console.WriteLine(n));

// IsIn - alternative to Contains
int value = 3;
bool exists = value.IsIn(1, 2, 3, 4, 5); // true

// NotWhere - inverse of Where
var filtered = numbers.NotWhere(n => n % 2 == 0); // [1, 3, 5]

// DoesNotContain
var list = new List<int> { 1, 2, 3 };
bool missing = list.DoesNotContain(4); // true
```

### JSON Converters

```csharp
using System.Text.Json;
using Smab.Helpers;

var options = new JsonSerializerOptions {
    Converters = {
        new JsonDateOnlyConverter(),
        new JsonTimeOnlyConverter(),
        new JsonUnixDateConverter()
    }
};

var obj = new MyClass {
    Date = new DateOnly(2024, 1, 15),
    Time = new TimeOnly(14, 30, 0)
};

string json = JsonSerializer.Serialize(obj, options);
// {"Date":"2024-01-15","Time":"14:30:00"}
```

### UTF-16 Characters

```csharp
using Smab.Helpers;

// Box drawing
Console.WriteLine(Utf16Chars.BOX_DRAWINGS_LIGHT_HORIZONTAL);
Console.WriteLine(Utf16Chars.BOX_DRAWINGS_LIGHT_VERTICAL);

// Arrows
Console.WriteLine(Utf16Chars.LEFTWARDS_ARROW);
Console.WriteLine(Utf16Chars.UPWARDS_ARROW);

// Mathematical symbols
Console.WriteLine(Utf16Chars.SQUARE_ROOT);
Console.WriteLine(Utf16Chars.INFINITY);

// Musical symbols
Console.WriteLine(Utf16Strings.Musical.STAFF_5_LINES);

// Block elements
Console.WriteLine(Utf16Chars.FULL_BLOCK);
Console.WriteLine(Utf16Chars.LIGHT_SHADE);
```

### Console Helpers

```csharp
using Smab.Helpers;

// Check for non-whitespace content
string input = "   ";
bool hasContent = input.HasNonWhiteSpaceContent(); // false

// Non-empty string check
string? text = GetSomeText();
if (text.NonEmptyString() is string validText) {
    Console.WriteLine(validText);
}
```

## API Documentation

The library extensively uses XML documentation comments. Enable IntelliSense in your IDE to get detailed descriptions, parameter information, and usage examples for all methods.

## Target Framework

- .NET 10.0

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests on [GitHub](https://github.com/smabuk/Smab.Helpers).

## License

This project is licensed under the MIT License.

## Author

Simon Brookes ([@smabuk](https://github.com/smabuk))

## Repository

[https://github.com/smabuk/Smab.Helpers](https://github.com/smabuk/Smab.Helpers)