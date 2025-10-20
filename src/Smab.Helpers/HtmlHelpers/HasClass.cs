namespace Smab.Helpers;

public static class HtmlHelpers {
	extension(string classString) {
		/// <summary>
		/// Determines whether the specified class name exists within a space-separated list of class names.
		/// </summary>
		/// <remarks>The comparison is case-insensitive and uses <see
		/// cref="StringComparer.InvariantCultureIgnoreCase"/>.</remarks>
		/// <param name="classString">The space-separated string of class names to search.</param>
		/// <param name="className">The class name to locate within the <paramref name="classString"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="className"/> is found in the <paramref name="classString"/>;
		/// otherwise, <see langword="false"/>.</returns>
		public bool HasClass(string className)
			=> classString.Split(' ').Contains(className, StringComparer.InvariantCultureIgnoreCase);
	}
}
