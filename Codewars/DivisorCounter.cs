namespace Codewars;

public sealed record DivisorCounter(long Number)
{
	public long GetTotalDivisorCount()
	{
		var counter = Number;
		var sqrt = (long)Math.Sqrt(Number);
		for (var factor = 2L; factor <= sqrt; factor++)
			counter += Number / factor;
		return counter * 2 - sqrt * sqrt;
	}
}