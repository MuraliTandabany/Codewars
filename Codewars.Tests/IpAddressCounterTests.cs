namespace Codewars.Tests;

public sealed class IpAddressCounterTests
{
	[TestCase("0.0.0.0", "0.0.0.0", 0)]
	[TestCase("10.0.0.0", "10.0.0.50", 50)]
	[TestCase("20.0.0.10", "20.0.1.0", 246)]
	[TestCase("0.0.0.0", "255.255.255.255", (1L << 32) - 1L)]
	public void CheckAvailableAddressCountBetweenIps(string start, string end, long expected) =>
		Assert.That(new IpAddressCounter(start, end).GetAddressCountBetweenIps(),
			Is.EqualTo(expected));
}