namespace Smab.Helpers.Tests.LinqHelperTests;

public class Also {
	[Fact]
	public void Also_WithSimpleAction_Should_ExecuteAction() {
		int value = 5;
		int sideEffect = 0;
		value.Also(x => sideEffect = x * 2);

		sideEffect.ShouldBe(10);
	}

	[Fact]
	public void Also_WithString_Should_ExecuteAction() {
		string value = "test";
		string? captured = null;
		value.Also(s => captured = s.ToUpper());

		captured.ShouldBe("TEST");
	}

	[Fact]
	public void Also_WithEmptyAction_Should_ExecuteWithoutError() {
		int value = 42;
		Should.NotThrow(() => value.Also(_ => { }));
	}

	[Fact]
	public void Also_WithMultipleStatements_Should_ExecuteAll() {
		int value = 10;
		int sum = 0;
		int product = 1;

		value.Also(x => {
			sum = x + 5;
			product = x * 2;
		});

		sum.ShouldBe(15);
		product.ShouldBe(20);
	}

	[Fact]
	public void Also_WithCollection_Should_AllowModification() {
		List<int> list = [1, 2, 3];
		list.Also(l => l.Add(4));

		list.Count.ShouldBe(4);
		list.ShouldBe([1, 2, 3, 4]);
	}

	[Fact]
	public void Also_WithLogging_Should_CaptureValue() {
		List<string> log = [];
		int value = 42;

		value.Also(x => log.Add($"Processing: {x}"));

		log.Count.ShouldBe(1);
		log[0].ShouldBe("Processing: 42");
	}

	[Fact]
	public void Also_UsedWithPipe_Should_AllowChaining() {
		List<string> log = [];

		int result = 5
			.Pipe(x => log.Add($"Start: {x}"))
			.Let(x => x * 2)
			.Pipe(x => log.Add($"After doubling: {x}"))
			.Let(x => x + 3);

		result.ShouldBe(13);
		log.Count.ShouldBe(2);
		log[0].ShouldBe("Start: 5");
		log[1].ShouldBe("After doubling: 10");
	}

	[Fact]
	public void Also_WithComplexObject_Should_AllowMutation() {
		var person = new Person { Name = "Alice", Age = 25 };

		person.Also(p => p.Age = 26);

		person.Age.ShouldBe(26);
		person.Name.ShouldBe("Alice");
	}

	[Fact]
	public void Also_WithNullableValue_Should_ExecuteAction() {
		int? nullableValue = 42;
		int? captured = null;

		nullableValue.Also(x => captured = x);

		captured.ShouldBe(42);
	}

	[Fact]
	public void Also_WithNullValue_Should_StillExecuteAction() {
		int? nullValue = null;
		bool actionExecuted = false;

		nullValue.Also(x => actionExecuted = true);

		actionExecuted.ShouldBeTrue();
	}

	[Fact]
	public void Also_WithValidation_Should_AllowSideEffectValidation() {
		int value = 15;
		bool isValid = false;

		value.Also(x => isValid = x > 10 && x < 20);

		isValid.ShouldBeTrue();
	}

	[Fact]
	public void Also_WithCounter_Should_IncrementCounter() {
		int counter = 0;

		5.Also(_ => counter++);
		10.Also(_ => counter++);
		15.Also(_ => counter++);

		counter.ShouldBe(3);
	}

	[Fact]
	public void Also_WithDictionary_Should_AllowModification() {
		Dictionary<string, int> dict = new() { ["a"] = 1, ["b"] = 2 };

		dict.Also(d => d["c"] = 3);

		dict.Count.ShouldBe(3);
		dict["c"].ShouldBe(3);
	}

	[Fact]
	public void Also_WithStringBuilder_Should_AllowAppend() {
		var sb = new System.Text.StringBuilder("Hello");

		sb.Also(builder => builder.Append(" World"));

		sb.ToString().ShouldBe("Hello World");
	}

	[Fact]
	public void Also_WithMultipleCalls_Should_ExecuteInOrder() {
		List<int> values = [];
		int value = 1;

		value.Also(x => values.Add(x));
		value.Also(x => values.Add(x * 2));
		value.Also(x => values.Add(x * 3));

		values.ShouldBe([1, 2, 3]);
	}

	[Fact]
	public void Also_WithBoolean_Should_ExecuteAction() {
		bool value = true;
		string? captured = null;

		value.Also(b => captured = b ? "yes" : "no");

		captured.ShouldBe("yes");
	}

	[Fact]
	public void Also_WithArray_Should_ExecuteSideEffect() {
		int[] array = [1, 2, 3];
		int sum = 0;

		array.Also(arr => sum = arr.Sum());

		sum.ShouldBe(6);
	}

	[Fact]
	public void Also_DifferenceFromPipe_Should_NotReturnValue() {
		int value = 5;
		int captured = 0;

		// Also returns void, so we can't chain with Let
		value.Also(x => captured = x * 2);

		// We need to verify the side effect happened
		captured.ShouldBe(10);

		// Compare with Pipe which returns the value
		int result = value.Pipe(x => captured = x * 3);
		result.ShouldBe(5);
		captured.ShouldBe(15);
	}

	private class Person {
		public string Name { get; set; } = "";
		public int Age { get; set; }
	}
}
