namespace DataStructure;

/// <summary>
/// https://www.codewars.com/kata/56b97b776ffcea598a0006f2
/// </summary>
public sealed record BubbleSort(int[] Input)
{
	public int[] SortOnce()
	{
		var result = (int[])Input.Clone();
		for (var index = 0; index < Input.Length - 1; index++)
			if (result[index] > result[index + 1])
				(result[index], result[index + 1]) = (result[index + 1], result[index]);
		return result;
	}
}