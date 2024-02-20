namespace Smab.Helpers.Tests.IoHelperTests;
public class GetArgument {
	private static readonly object[] arguments = [1, 2, 3, "four", '5', 6.0];

	[Theory]
	[InlineData(1,   0,      1, typeof(int))]
	[InlineData(2,   0,      2, typeof(int))]
	[InlineData(3,   0,      3, typeof(int))]
	[InlineData(4, "0", "four", typeof(string))]
	[InlineData(5, '0',    '5', typeof(char))]
	[InlineData(6, 0.0,    6.0, typeof(double))]
	public void GetArgument_WithDefaults_Should_Return(int index, object defaultValue, object expectedValue, Type expectedType) {
		ArgumentHelpers.GetArgument(arguments, index, defaultValue).ShouldBeOfType(expectedType);
		ArgumentHelpers.GetArgument(arguments, index, defaultValue).ShouldBe(expectedValue);
		ArgumentHelpers.GetArgument([], index, defaultValue).ShouldBe(defaultValue);
	}

	[Theory]
	[InlineData(1,      1, typeof(int))]
	[InlineData(2,      2, typeof(int))]
	[InlineData(3,      3, typeof(int))]
	[InlineData(4, "four", typeof(string))]
	[InlineData(5,    '5', typeof(char))]
	[InlineData(6,    6.0, typeof(double))]
	public void GetArgument_Should_Return(int index, object expectedValue, Type expectedType) {
		object actual = expectedValue switch {
			_ when expectedValue is int    => ArgumentHelpers.GetArgument<int>(arguments, index),
			_ when expectedValue is char   => ArgumentHelpers.GetArgument<char>(arguments, index),
			_ when expectedValue is string => ArgumentHelpers.GetArgument<string>(arguments, index),
			_ when expectedValue is double => ArgumentHelpers.GetArgument<double>(arguments, index),
			_ => throw new NotImplementedException()
		};

		actual.ShouldBeOfType(expectedType);
		actual.ShouldBe(expectedValue);
	}
}
