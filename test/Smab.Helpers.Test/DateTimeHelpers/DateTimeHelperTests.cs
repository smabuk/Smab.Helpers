namespace Smab.Helpers.Test.DateTimeHelpers;
public class DateTimeHelperTests {
	[Fact]
	public void MonthYear_Formats_ShouldBe() {
		DateTime dateTime = new(2024, 02, 15, 13, 01, 04);
		DateOnly dateOnly = new(2024, 09, 15);

		dateTime.ToDateLongMonthYearString().ShouldBe("15 February, 2024");
		dateOnly.ToDateLongMonthYearString().ShouldBe("15 September, 2024");

		dateTime.ToDateShortMonthYearString().ShouldBe("15 Feb, 2024");
		dateOnly.ToDateShortMonthYearString().ShouldBe("15 Sept, 2024");
	}
}
