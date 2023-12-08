namespace Smab.Helpers;

public static class HtmlHelper {

	public static bool HasClass(this string classString, string className)
		=> classString.Split(' ').Contains(className, StringComparer.InvariantCultureIgnoreCase);

}
