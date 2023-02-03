using System.Collections.Generic;

namespace Codewars.Tests;

public sealed class UniqueElementsWithOrderTests
{
	[TestCase("", "")]
	[TestCase("A", "A")]
	[TestCase("AA", "A")]
	[TestCase("AB", "AB")]
	[TestCase("ABBCcAD", "ABCcAD")]
	[TestCase("AAAABBBCCDAABBB", "ABCDAB")]
	public void Get(string input, string expected) =>
		Assert.That(new UniqueElementsWithOrder<char>(input).Get(), Is.EqualTo(expected));

	[TestCase(new[] { 1, 2, 2, 4, 4 }, new[] { 1, 2, 4 })]
	[TestCase(new[] { 1, 2, 2, 4, 4, 6, 7, 7, 8, 7 }, new[] { 1, 2, 4, 6, 7, 8, 7 })]
	public void Get(IEnumerable<int> input, IEnumerable<int> expected) =>
		Assert.That(new UniqueElementsWithOrder<int>(input).Get(), Is.EqualTo(expected));
}