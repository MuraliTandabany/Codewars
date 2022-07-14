namespace Codewars.Tests;

public sealed class DivisorCounterTests
{
	[TestCase(1L, 1L)]
	[TestCase(2L, 3L)]
	[TestCase(3L, 5L)]
	[TestCase(4L, 8L)]
	[TestCase(5L, 10L)]
	[TestCase(6L, 14L)]
	[TestCase(20L, 66L)]
	[TestCase(10000000L, 162725364)]
	public void GetTotalDivisorCount(long number, long expected) =>
		Assert.That(new DivisorCounter(number).GetTotalDivisorCount(), Is.EqualTo(expected));

	//ncrunch: no coverage start
	[Category("Slow")]
	[TestCase(999999999999999L, 34693207724723990L)]
	[TestCase(999999999999998L, 34693207724723862L)]
	[TestCase(999999999999995L, 34693207724723818L)]
	[TestCase(999999999999950L, 34693207724722436L)]
	public void GetTotalDivisorCountSlow(long number, long expected) =>
		Assert.That(new DivisorCounter(number).GetTotalDivisorCount(), Is.EqualTo(expected));
}