namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/54e6533c92449cc251001667/
/// </summary>
public sealed record UniqueElementsWithOrder<Element>(IEnumerable<Element> Elements)
{
	public IEnumerable<Element> Get() =>
		Elements.Where((element, index) => element is not null && !element.Equals(Elements.ElementAtOrDefault(index - 1)));
}