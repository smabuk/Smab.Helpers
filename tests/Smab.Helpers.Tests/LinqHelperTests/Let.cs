namespace Smab.Helpers.Tests.LinqHelperTests;

public class Let {
	[Fact]
	public void Let_WithSimpleTransformation_Should_ReturnTransformedValue() {
		int value = 5;
		int result = value.Let(x => x * 2);
		result.ShouldBe(10);
	}

	[Fact]
	public void Let_WithStringTransformation_Should_ReturnTransformedString() {
		string value = "hello";
		string result = value.Let(s => s.ToUpper());
		result.ShouldBe("HELLO");
	}

	[Fact]
	public void Let_WithTypeConversion_Should_ReturnDifferentType() {
		int value = 42;
		string result = value.Let(x => x.ToString());
		result.ShouldBe("42");
	}

	[Fact]
	public void Let_WithComplexObject_Should_TransformObject() {
		var person = new { Name = "John", Age = 30 };
		string result = person.Let(p => $"{p.Name} is {p.Age} years old");
		result.ShouldBe("John is 30 years old");
	}

	[Fact]
	public void Let_WithChainedOperations_Should_AllowFunctionalComposition() {
		int result = 5
			.Let(x => x * 2)
			.Let(x => x + 3)
			.Let(x => x * x);
		result.ShouldBe(169); // ((5 * 2) + 3)^2 = 13^2 = 169
	}

	[Fact]
	public void Let_WithNullableValue_Should_HandleNull() {
		int? nullableValue = null;
		string result = nullableValue.Let(x => x?.ToString() ?? "null");
		result.ShouldBe("null");
	}

	[Fact]
	public void Let_WithNullableValue_Should_HandleNonNull() {
		int? nullableValue = 42;
		string result = nullableValue.Let(x => x?.ToString() ?? "null");
		result.ShouldBe("42");
	}

	[Fact]
	public void Let_WithCollection_Should_TransformCollection() {
		int[] numbers = [1, 2, 3, 4, 5];
		int result = numbers.Let(arr => arr.Sum());
		result.ShouldBe(15);
	}

	[Fact]
	public void Let_WithInlineScopeCreation_Should_AllowTemporaryVariables() {
		int result = 10.Let(x => {
			int doubled = x * 2;
			int squared = doubled * doubled;
			return squared + x;
		});
		result.ShouldBe(410); // (10 * 2)^2 + 10 = 400 + 10 = 410
	}

	[Fact]
	public void Let_WithDoubleToInt_Should_ReturnInt() {
		double value = 3.14;
		int result = value.Let(x => (int)x);
		result.ShouldBe(3);
	}

	[Fact]
	public void Let_WithBooleanLogic_Should_EvaluateCorrectly() {
		int value = 15;
		bool result = value.Let(x => x > 10 && x < 20);
		result.ShouldBeTrue();
	}

	[Fact]
	public void Let_WithTupleDeconstruction_Should_Work() {
		var tuple = (First: 5, Second: 10);
		int result = tuple.Let(t => t.First + t.Second);
		result.ShouldBe(15);
	}

	[Fact]
	public void Let_WithNestedLet_Should_AllowNestedScopes() {
		int result = 5.Let(x =>
			10.Let(y => x * y)
		);
		result.ShouldBe(50);
	}

	[Fact]
	public void Let_WithZeroValue_Should_HandleZero() {
		int value = 0;
		string result = value.Let(x => x == 0 ? "zero" : "non-zero");
		result.ShouldBe("zero");
	}

	[Fact]
	public void Let_WithEmptyString_Should_HandleEmptyString() {
		string value = "";
		bool result = value.Let(s => string.IsNullOrEmpty(s));
		result.ShouldBeTrue();
	}

	[Fact]
	public void LetOrDefault_WithNullValue_Should_ReturnDefault() {
		string? nullValue = null;
		int? result = nullValue.LetOrDefault(s => s.Length);
		result.ShouldBe(0); // default(int) is 0
	}

	[Fact]
	public void LetOrDefault_WithNullValue_Should_ReturnDefaultForValueType() {
		string? nullValue = null;
		int? nullable = nullValue.LetOrDefault(s => s.Length);
		nullable.ShouldBe(0); // default(int) is 0
	}

	[Fact]
	public void LetOrDefault_WithNonNullValue_Should_ReturnTransformedValue() {
		string? value = "hello";
		int? result = value.LetOrDefault(s => s.Length);
		result.ShouldBe(5);
	}

	[Fact]
	public void LetOrDefault_WithNonNullString_Should_TransformCorrectly() {
		string? value = "test";
		string? result = value.LetOrDefault(s => s.ToUpper());
		result.ShouldBe("TEST");
	}

	[Fact]
	public void LetOrDefault_WithNullObject_Should_ReturnNull() {
		Person? person = null;
		string? result = person.LetOrDefault(p => p.Name);
		result.ShouldBeNull();
	}

	[Fact]
	public void LetOrDefault_WithNonNullObject_Should_ReturnProperty() {
		Person? person = new("Alice", 25);
		string? result = person.LetOrDefault(p => p.Name);
		result.ShouldBe("Alice");
	}

	[Fact]
	public void LetOrDefault_WithNullArray_Should_ReturnDefault() {
		int[]? nullArray = null;
		int? result = nullArray.LetOrDefault(arr => arr.Length);
		result.ShouldBe(0); // default(int) is 0
	}

	[Fact]
	public void LetOrDefault_WithNonNullArray_Should_ReturnSum() {
		int[]? array = [1, 2, 3, 4, 5];
		int? result = array.LetOrDefault(arr => arr.Sum());
		result.ShouldBe(15);
	}

	[Fact]
	public void LetOrDefault_WithNullList_Should_ReturnNull() {
		List<string>? nullList = null;
		int? result = nullList.LetOrDefault(list => list.Count);
		result.ShouldBe(0); // default(int) is 0
	}

	[Fact]
	public void LetOrDefault_WithNonNullList_Should_ReturnCount() {
		List<string>? list = ["a", "b", "c"];
		int? result = list.LetOrDefault(list => list.Count);
		result.ShouldBe(3);
	}

	[Fact]
	public void LetOrDefault_WithTypeConversion_Should_Work() {
		string? value = "42";
		int? result = value.LetOrDefault(s => int.Parse(s));
		result.ShouldBe(42);
	}

	[Fact]
	public void LetOrDefault_WithNullTypeConversion_Should_ReturnDefault() {
		string? nullValue = null;
		int? result = nullValue.LetOrDefault(s => int.Parse(s));
		result.ShouldBe(0); // default(int) is 0
	}

	[Fact]
	public void LetOrDefault_WithNullValue_Should_ReturnDefaultInt() {
		string? nullValue = null;
		int? result = nullValue.LetOrDefault(s => s.Length);
		result.ShouldBe(0); // default(int) is 0, not null
	}

	[Fact]
	public void LetOrDefault_ChainedWithLetOnNull_Should_UseDefault() {
		string? nullValue = null;
		int result = (nullValue.LetOrDefault(s => s.ToUpper()) ?? "DEFAULT")
			.Let(s => s.Length);
		result.ShouldBe(7); // "DEFAULT".Length
	}

	[Fact]
	public void LetOrDefault_WithComplexTransformation_Should_Work() {
		Person? person = new("Bob", 30);
		string? result = person.LetOrDefault(p => $"{p.Name} is {p.Age} years old");
		result.ShouldBe("Bob is 30 years old");
	}

	[Fact]
	public void LetOrDefault_WithNullComplexTransformation_Should_ReturnNull() {
		Person? person = null;
		string? result = person.LetOrDefault(p => $"{p.Name} is {p.Age} years old");
		result.ShouldBeNull();
	}

	[Fact]
	public void LetOrDefault_WithEmptyString_Should_NotTreatAsNull() {
		string? value = "";
		int? result = value.LetOrDefault(s => s.Length);
		result.ShouldBe(0);
	}

	[Fact]
	public void LetOrDefault_WithWhitespaceString_Should_NotTreatAsNull() {
		string? value = "   ";
		int? result = value.LetOrDefault(s => s.Length);
		result.ShouldBe(3);
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_Should_ReturnCustomValue() {
		string? nullValue = null;
		int result = nullValue.LetOrDefault(s => s.Length, -1);
		result.ShouldBe(-1);
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_Should_ReturnTransformedValue() {
		string? value = "hello";
		int result = value.LetOrDefault(s => s.Length, -1);
		result.ShouldBe(5);
	}

	[Fact]
	public void LetOrDefault_WithCustomStringDefault_Should_ReturnCustomValue() {
		string? nullValue = null;
		string result = nullValue.LetOrDefault(s => s.ToUpper(), "DEFAULT");
		result.ShouldBe("DEFAULT");
	}

	[Fact]
	public void LetOrDefault_WithCustomStringDefault_Should_ReturnTransformedValue() {
		string? value = "test";
		string result = value.LetOrDefault(s => s.ToUpper(), "DEFAULT");
		result.ShouldBe("TEST");
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_OnNullArray_Should_ReturnCustomValue() {
		int[]? nullArray = null;
		int result = nullArray.LetOrDefault(arr => arr.Sum(), -999);
		result.ShouldBe(-999);
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_OnArray_Should_ReturnSum() {
		int[]? array = [1, 2, 3, 4, 5];
		int result = array.LetOrDefault(arr => arr.Sum(), -999);
		result.ShouldBe(15);
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_ChainedWithLet_Should_Work() {
		string? nullValue = null;
		int result = nullValue
			.LetOrDefault(s => s.ToUpper(), "FALLBACK")
			.Let(s => s.Length);
		result.ShouldBe(8); // "FALLBACK".Length
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_OnPerson_Should_ReturnCustomValue() {
		Person? person = null;
		string result = person.LetOrDefault(p => p.Name, "Unknown");
		result.ShouldBe("Unknown");
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_OnPerson_Should_ReturnName() {
		Person? person = new("Alice", 25);
		string result = person.LetOrDefault(p => p.Name, "Unknown");
		result.ShouldBe("Alice");
	}

	[Fact]
	public void LetOrDefault_WithCustomDefaultZero_Should_ReturnZero() {
		string? nullValue = null;
		int result = nullValue.LetOrDefault(s => s.Length, 0);
		result.ShouldBe(0);
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_ComplexTransformation_Should_ReturnDefault() {
		Person? person = null;
		string result = person.LetOrDefault(
			p => $"{p.Name} is {p.Age} years old",
			"No person available"
		);
		result.ShouldBe("No person available");
	}

	[Fact]
	public void LetOrDefault_WithCustomDefault_ComplexTransformation_Should_Transform() {
		Person? person = new("Bob", 30);
		string result = person.LetOrDefault(
			p => $"{p.Name} is {p.Age} years old",
			"No person available"
		);
		result.ShouldBe("Bob is 30 years old");
	}

	private record Person(string Name, int Age);
}
