namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/51e04f6b544cf3f6550000c1
/// </summary>
public sealed record Beeramid(int Bonus, double BeerCanPrice)
{
	public int GetCompleteLevelCount() =>
		CalculateCompleteLevelCount((int)(Bonus / BeerCanPrice), 0);

	private static int CalculateCompleteLevelCount(int numberOfCans, int levelCount)
	{
		numberOfCans -= levelCount * levelCount;
		return numberOfCans < (levelCount + 1) * (levelCount + 1)
			? levelCount
			// ReSharper disable once TailRecursiveCall
			: CalculateCompleteLevelCount(numberOfCans, levelCount + 1);
	}
}