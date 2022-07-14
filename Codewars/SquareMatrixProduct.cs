namespace Codewars;

public sealed class SquareMatrixProduct
{
	public SquareMatrixProduct(int[,] a, int[,] b)
	{
		this.a = a;
		this.b = b;
	}

	private readonly int[,] a;
	private readonly int[,] b;

	public int[,] MatrixMultiplication()
	{
		var dimensions = a.GetLength(0);
		var result = new int[dimensions, dimensions];
		for (var outerRow = 0; outerRow < dimensions; outerRow++)
		for (var outerColumn = 0; outerColumn < dimensions; outerColumn++)
		for (var cell = 0; cell < dimensions; cell++)
			result[outerRow, outerColumn] += a[outerRow, cell] * b[cell, outerColumn];
		return result;
	}
}