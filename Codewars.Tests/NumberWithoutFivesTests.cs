namespace Codewars.Tests;

public sealed class NumberWithoutFivesTests
{
	[TestCase(4, 17, 12)]
	[TestCase(4, 18, 13)]
	[TestCase(-5, 5, 9)]
	public void CountNumbersWithoutFives(long start, long end, long expected) =>
		Assert.That(new NumberWithoutFives().Count(start, end), Is.EqualTo(expected));

	[Test]
	public void CountWithSameStartAndEnd_ShouldReturnOne() =>
		Assert.That(new NumberWithoutFives().Count(0, 0), Is.EqualTo(1));
}