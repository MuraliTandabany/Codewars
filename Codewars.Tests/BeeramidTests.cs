namespace Codewars.Tests;

public sealed class BeeramidTests
{
	[TestCase(0, 4, 0)]
	[TestCase(1, 1, 1)]
	[TestCase(10, 2, 2)]
	[TestCase(21, 1.5, 3)]
	[TestCase(60, 2, 4)]
	[TestCase(454, 5, 5)]
	[TestCase(455, 5, 6)]
	public void GetCompleteLevelCount(int bonus, double beerCanPrice, int expectedCount) =>
		Assert.That(new Beeramid(bonus, beerCanPrice).GetCompleteLevelCount(),
			Is.EqualTo(expectedCount));
}