using System.Numerics;

namespace Codewars.Tests;

public sealed class BitCountTests
{
	[TestCase(1, 1)]
	[TestCase(3, 4)]
	[TestCase(4, 5)]
	[TestCase(5, 7)]
	[TestCase(6, 9)]
	[TestCase(7, 12)]
	[TestCase(8, 13)]
	[TestCase(11, 20)]
	[TestCase(1451242512042, 29019745448285)]
	public void FindOnesCount(long number, long expectedValue) =>
		Assert.That(new BitCount(0, 1).FindOnesCountTillNumber(number),
			Is.EqualTo(new BigInteger(expectedValue)));

	[TestCase(4, 7, 8)]
	[TestCase(12, 29, 51)]
	public void CountOnesBetweenTwoNumbers(long left, long right, long expectedValue) =>
		Assert.That(new BitCount(left, right).CountOneBits(),
			Is.EqualTo(new BigInteger(expectedValue)));
}