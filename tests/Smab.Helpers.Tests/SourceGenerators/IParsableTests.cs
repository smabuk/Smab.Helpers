using Smab.Helpers.IParsableSourceGenerator;

namespace Smab.Helpers.Tests.SourceGenerators;

public class IParsableTests
{
	[Theory]
	[InlineData("42")]
	[InlineData("123")]
	[InlineData("-5")]
	public void SingleIntParameter_Parses(string input)
	{
		TestNumber result = TestNumber.Parse(input);
		result.Value.ShouldBe(int.Parse(input));
	}

	[Theory]
	[InlineData("42", true)]
	[InlineData("abc", false)]
	[InlineData("", false)]
	[InlineData(null, false)]
	public void SingleIntParameter_TryParse(string? input, bool expectedSuccess)
	{
		bool success = TestNumber.TryParse(input, null, out TestNumber? result);
		success.ShouldBe(expectedSuccess);
		if (success)
		{
			result!.Value.ShouldBe(int.Parse(input!));
		}
	}

	[Theory]
	[InlineData("10,20", 10, 20)]
	[InlineData("10 20", 10, 20)]
	[InlineData("  -5  ,  15  ", -5, 15)]
	public void MultiParameter_WithDefaultSplit_Parses(string input, int expectedX, int expectedY)
	{
		TestPoint result = TestPoint.Parse(input);
		result.X.ShouldBe(expectedX);
		result.Y.ShouldBe(expectedY);
	}

	[Theory]
	[InlineData("10:20", 10, 20)]
	[InlineData("-5:15", -5, 15)]
	public void MultiParameter_WithCustomSplitPattern_Parses(string input, int expectedX, int expectedY)
	{
		TestPointWithPattern result = TestPointWithPattern.Parse(input);
		result.X.ShouldBe(expectedX);
		result.Y.ShouldBe(expectedY);
	}

	[Fact]
	public void MultiParameter_WithCapturePattern_Parses()
	{
		string input = "Point: X=10, Y=20";
		TestPointWithCapture result = TestPointWithCapture.Parse(input);
		result.X.ShouldBe(10);
		result.Y.ShouldBe(20);
	}

	[Theory]
	[InlineData("1,2,3")]
	[InlineData("10 20 30 40")]
	public void CollectionParameter_Parses(string input)
	{
		TestIntList result = TestIntList.Parse(input);
		result.Values.ShouldNotBeEmpty();
	}

	[Fact]
	public void CollectionParameter_ParsesCorrectValues()
	{
		string input = "1,2,3,4,5";
		TestIntList result = TestIntList.Parse(input);
		result.Values.Count.ShouldBe(5);
		result.Values[0].ShouldBe(1);
		result.Values[4].ShouldBe(5);
	}

	[Fact]
	public void GenericType_WithIParsableConstraint_Parses()
	{
		string input = "42";
		TestWrapper<int> result = TestWrapper<int>.Parse(input);
		result.Value.ShouldBe(42);
	}

	[Theory]
	[InlineData("test", "test")]
	[InlineData("hello world", "hello world")]
	public void SingleStringParameter_Parses(string input, string expected)
	{
		TestString result = TestString.Parse(input);
		result.Text.ShouldBe(expected);
	}

	[Fact]
	public void ImplementsIParsableInterface()
	{
		Type type = typeof(TestNumber);
		bool implementsIParsable = type.GetInterfaces().Any(i =>
			i.IsGenericType &&
			i.GetGenericTypeDefinition() == typeof(IParsable<>) &&
			i.GetGenericArguments()[0] == type);

		implementsIParsable.ShouldBeTrue();
	}

	[Fact]
	public void HasParseMethod()
	{
		var parseMethod = typeof(TestNumber).GetMethod("Parse",
			[typeof(string), typeof(IFormatProvider)]);

		parseMethod.ShouldNotBeNull();
		parseMethod!.IsStatic.ShouldBeTrue();
		parseMethod.ReturnType.ShouldBe(typeof(TestNumber));
	}

	[Fact]
	public void HasTryParseMethod()
	{
		var tryParseMethod = typeof(TestNumber).GetMethods()
			.FirstOrDefault(m =>
				m.Name == "TryParse" &&
				m.IsStatic &&
				m.GetParameters().Length == 3);

		tryParseMethod.ShouldNotBeNull();
		tryParseMethod!.ReturnType.ShouldBe(typeof(bool));
	}
}

[GenerateIParsable]
internal partial record TestNumber(int Value);

[GenerateIParsable(SplitChars = " ,")]
internal partial record TestPoint(int X, int Y);

[GenerateIParsable(SplitPattern = ":")]
internal partial record TestPointWithPattern(int X, int Y);

[GenerateIParsable(CapturePattern = @"Point: X=(?<X>-?\d+), Y=(?<Y>-?\d+)")]
internal partial record TestPointWithCapture(int X, int Y);

[GenerateIParsable(SplitChars = " ,")]
internal partial record TestIntList(List<int> Values);

[GenerateIParsable]
internal partial record TestWrapper<T>(T Value) where T : IParsable<T>;

[GenerateIParsable]
internal partial record TestString(string Text);
