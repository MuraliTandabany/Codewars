namespace DataStructure.Tests;

public sealed class BubbleSortTests
{
	[TestCase(new int[0], new int[0])]
	[TestCase(new[] { 1 }, new[] { 1 })]
	[TestCase(new[] { 5, 4 }, new[] { 4, 5 })]
	[TestCase(new[] { 2, 4 }, new[] { 2, 4 })]
	[TestCase(new[] { 5, 4, 3 }, new[] { 4, 3, 5 })]
	[TestCase(new[] { 9, 7, 5, 3, 1, 2, 4, 6, 8 }, new[] { 7, 5, 3, 1, 2, 4, 6, 8, 9 })]
	public void OneCompletePass(int[] input, int[] expected) =>
		Assert.That(new BubbleSort(input).SortOnce(), Is.EqualTo(expected));

	[Test]
	public void InputShouldNotBeMutated()
	{
		var input = new[] { 5, 4, 3, 2 };
		new BubbleSort(input).SortOnce();
		Assert.That(input, Is.EqualTo(new[] { 5, 4, 3, 2 }));
	}
}