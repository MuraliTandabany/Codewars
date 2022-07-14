using System.Numerics;

namespace Codewars;

public sealed class LargestProduct
{
	public LargestProduct(string data) => this.data = data;
	private readonly string data;

	public BigInteger FindLargestProduct(int numberOfDigits)
	{
		BigInteger largest = 0;
		for (var i = 0; i < data.Length - numberOfDigits + 1; i++)
		{
			BigInteger product = 1;
			var currentWindow = data.Substring(i, numberOfDigits);
			foreach (var character in currentWindow)
				product *= int.Parse(character.ToString());
			if (product > largest)
				largest = product;
		}
		return largest;
	}

	public BigInteger FindLargestProduct() => CalculateProduct(0, 100, 0);

	private BigInteger CalculateProduct(int currentIndex, int lastIndex, BigInteger product)
	{
		while (currentIndex <= lastIndex)
		{
			var midIndex = (lastIndex + currentIndex) / 2;
			var midIndexProduct = FindLargestProduct(midIndex);
			if (midIndexProduct == product)
				return product;
			if (midIndexProduct > product)
			{
				product = midIndexProduct;
				currentIndex = midIndex;
			}
			else if (midIndexProduct == 0)
			{
				lastIndex = midIndex;
			}
		}
		return product; //ncrunch: no coverage
	}
}