namespace Smab.Helpers.Tests.LinqHelperTests;

public class Pipe {
	[Fact]
	public void Pipe_WithSimpleAction_Should_ReturnOriginalValue() {
		int value = 5;
		int result = value.Pipe(x => { });
		result.ShouldBe(5);
	}

	[Fact]
	public void Pipe_WithSideEffect_Should_ExecuteActionAndReturnOriginal() {
		int value = 10;
		int sideEffect = 0;
		int result = value.Pipe(x => sideEffect = x * 2);

		result.ShouldBe(10);
		sideEffect.ShouldBe(20);
	}

	[Fact]
	public void Pipe_WithString_Should_ReturnOriginalString() {
		string value = "test";
#pragma warning disable CA1806 // Do not ignore method results
		string result = value.Pipe(s => s.ToUpper());
#pragma warning restore CA1806 // Do not ignore method results
		result.ShouldBe("test");
	}

	[Fact]
	public void Pipe_WithLogging_Should_AllowLoggingInPipeline() {
		List<string> logged = [];
		int result = 5
			.Pipe(x => logged.Add($"Initial: {x}"))
			.Let(x => x * 2)
			.Pipe(x => logged.Add($"After doubling: {x}"))
			.Let(x => x + 3)
			.Pipe(x => logged.Add($"After adding 3: {x}"));

		result.ShouldBe(13);
		logged.Count.ShouldBe(3);
		logged[0].ShouldBe("Initial: 5");
		logged[1].ShouldBe("After doubling: 10");
		logged[2].ShouldBe("After adding 3: 13");
	}

	[Fact]
	public void Pipe_WithMultipleSideEffects_Should_ExecuteAllActions() {
		int value = 7;
		List<int> results = [];

		int finalValue = value
			.Pipe(x => results.Add(x))
			.Pipe(x => results.Add(x * 2))
			.Pipe(x => results.Add(x * 3));

		finalValue.ShouldBe(7);
		results.ShouldBe([7, 14, 21]);
	}

	[Fact]
	public void Pipe_WithCollection_Should_ReturnOriginalCollection() {
		int[] numbers = [1, 2, 3];
		int sum = 0;

		int[] result = numbers.Pipe(arr => sum = arr.Sum());

		result.ShouldBe(numbers);
		sum.ShouldBe(6);
	}

	[Fact]
	public void Pipe_WithNullableValue_Should_HandleNull() {
		int? nullableValue = null;
		bool actionExecuted = false;

		int? result = nullableValue.Pipe(x => actionExecuted = true);

		result.ShouldBeNull();
		actionExecuted.ShouldBeTrue();
	}

	[Fact]
	public void Pipe_WithNullableValue_Should_HandleNonNull() {
		int? nullableValue = 42;
		int? capturedValue = null;

		int? result = nullableValue.Pipe(x => capturedValue = x);

		result.ShouldBe(42);
		capturedValue.ShouldBe(42);
	}

	[Fact]
	public void Pipe_WithComplexObject_Should_AllowInspection() {
		var person = new { Name = "Jane", Age = 25 };
		string capturedName = "";
		int capturedAge = 0;

		var result = person.Pipe(p => {
			capturedName = p.Name;
			capturedAge = p.Age;
		});

		result.ShouldBe(person);
		capturedName.ShouldBe("Jane");
		capturedAge.ShouldBe(25);
	}

	[Fact]
	public void Pipe_InFunctionalPipeline_Should_EnableDebugging() {
		List<string> debugLog = [];

		int result = 10
			.Let(x => x * 2)
			.Pipe(x => debugLog.Add($"After first operation: {x}"))
			.Let(x => x + 5)
			.Pipe(x => debugLog.Add($"After second operation: {x}"))
			.Let(x => x / 5);

		result.ShouldBe(5);
		debugLog.Count.ShouldBe(2);
		debugLog[0].ShouldBe("After first operation: 20");
		debugLog[1].ShouldBe("After second operation: 25");
	}

	[Fact]
	public void Pipe_WithCounter_Should_IncrementCounter() {
		int counter = 0;
		int result = 5
			.Pipe(_ => counter++)
			.Pipe(_ => counter++)
			.Pipe(_ => counter++);

		result.ShouldBe(5);
		counter.ShouldBe(3);
	}

	[Fact]
	public void Pipe_WithEmptyAction_Should_ReturnOriginal() {
		string value = "unchanged";
		string result = value.Pipe(_ => { });
		result.ShouldBe("unchanged");
	}

	[Fact]
	public void Pipe_WithModifyingExternalState_Should_ModifyState() {
		var state = new { Value = 0 };
		var newState = new { Value = 0 };

		int result = 42.Pipe(x => newState = new { Value = x });

		result.ShouldBe(42);
		newState.Value.ShouldBe(42);
		state.Value.ShouldBe(0);
	}

	[Fact]
	public void Pipe_WithBooleanValue_Should_ReturnOriginalBoolean() {
		bool value = true;
		int sideEffectValue = 0;

		bool result = value.Pipe(b => sideEffectValue = b ? 1 : 0);

		result.ShouldBeTrue();
		sideEffectValue.ShouldBe(1);
	}

	[Fact]
	public void Pipe_WithZeroValue_Should_HandleZero() {
		int value = 0;
		bool wasZero = false;

		int result = value.Pipe(x => wasZero = x == 0);

		result.ShouldBe(0);
		wasZero.ShouldBeTrue();
	}

	[Fact]
	public void Pipe_WithEmptyString_Should_HandleEmptyString() {
		string value = "";
		bool isEmpty = false;

		string result = value.Pipe(s => isEmpty = string.IsNullOrEmpty(s));

		result.ShouldBe("");
		isEmpty.ShouldBeTrue();
	}

	[Fact]
	public void Pipe_CombinedWithLet_Should_AllowFullFunctionalComposition() {
		List<string> operations = [];

		int result = 1
			.Pipe(x => operations.Add($"Start: {x}"))
			.Let(x => x + 1)
			.Pipe(x => operations.Add($"After +1: {x}"))
			.Let(x => x * 10)
			.Pipe(x => operations.Add($"After *10: {x}"))
			.Let(x => x - 5);

		result.ShouldBe(15);
		operations.Count.ShouldBe(3);
		operations[0].ShouldBe("Start: 1");
		operations[1].ShouldBe("After +1: 2");
		operations[2].ShouldBe("After *10: 20");
	}
}
