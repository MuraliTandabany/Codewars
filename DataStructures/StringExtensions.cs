namespace DataStructure;

public static class StringExtensions
{
	public static string ToCamelCaseSplitByHyphenAndUnderscore(this string input) =>
		string.Concat(input.Split('-', '_').Select((word, index) => index > 0
			? char.ToUpper(word[0]) + word[1..]
			: word));
}