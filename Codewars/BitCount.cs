using System.Numerics;

namespace Codewars;

public sealed class BitCount
{
	public BitCount(long left, long right)
	{
		this.left = left;
		this.right = right;
	}

	private readonly long left;
	private readonly long right;

	public BigInteger CountOneBits() =>
		FindOnesCountTillNumber(right) - FindOnesCountTillNumber(left - 1);

	public BigInteger FindOnesCountTillNumber(long number)
	{
		var result = 0L;
		var numberOfBits = (long)Math.Floor(Math.Log2(number)) + 1;
		for (var bit = 0; bit < numberOfBits; bit++)
			result += OnesCountPerBit(bit, number + 1);
		return result;
	}

	private static long OnesCountPerBit(int bit, long nextNumber)
	{
		var multiplier = 1L << bit;
		var step = 2L << bit;
		var onesWithFraction = (double)nextNumber / step;
		var onesWithoutFraction = nextNumber / step;
		var count = onesWithoutFraction * multiplier;
		count += Math.Max(0, (long)(step * (onesWithFraction - onesWithoutFraction)) - multiplier);
		return count;
	}
}
