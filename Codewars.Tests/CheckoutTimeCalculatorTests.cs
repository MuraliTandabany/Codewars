using System;

namespace Codewars.Tests;

public sealed class CheckoutTimeCalculatorTests
{
	[Test]
	public void EmptyQueue() =>
		Assert.That(new CheckoutTimeCalculator(Array.Empty<int>(), 1).Calculate(), Is.EqualTo(0));

	[TestCase(new[] { 5 }, 1, 5)]
	[TestCase(new[] { 5, 10 }, 1, 15)]
	[TestCase(new[] { 5, 10, 25, 45, 4, 12 }, 1, 101)]
	[TestCase(new[] { 5 }, 2, 5)]
	[TestCase(new[] { 5, 10 }, 2, 10)]
	[TestCase(new[] { 10, 2, 3, 4 }, 2, 10)]
	[TestCase(new[] { 2, 2, 3, 3, 4, 4 }, 2, 9)]
	[TestCase(new[] { 1, 2, 3, 4, 5 }, 100, 5)]
	public void Calculate(int[] customerQueue, int numberOfCounters, int expectedTime) =>
		Assert.That(new CheckoutTimeCalculator(customerQueue, numberOfCounters).Calculate(),
			Is.EqualTo(expectedTime));
}