namespace Smab.Helpers;

public static class HtmlHelpers {
	public static bool HasClass(this string classString, string className)
		=> classString.Split(' ').Contains(className, StringComparer.InvariantCultureIgnoreCase);
}
