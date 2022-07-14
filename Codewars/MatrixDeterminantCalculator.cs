namespace Codewars;

public sealed class MatrixDeterminantCalculator
{
	public MatrixDeterminantCalculator(int[][] matrix) => this.matrix = matrix;
	private readonly int[][] matrix;

	public int Calculate()
	{
		if (matrix.Length == 1)
			return matrix[0][0];
		var result = 0;
		for (var i = 0; i < matrix.Length; i++)
		{
			var subMatrixProduct = matrix[0][i] * GetMinorMatrix(i, matrix).Calculate();
			if (i % 2 == 0)
				result += subMatrixProduct;
			else
				result -= subMatrixProduct;
		}
		return result;
	}

	private static MatrixDeterminantCalculator GetMinorMatrix(int slicePosition, IReadOnlyList<int[]> matrix)
	{
		var minorMatrix = new int[matrix.Count - 1][];
		for (var row = 1; row < matrix.Count; row++)
		{
			minorMatrix[row - 1] = new int [matrix.Count - 1];
			for (var column = 0; column < matrix.Count; column++)
				if (column != slicePosition)
					minorMatrix[row - 1][column > slicePosition
						? column - 1
						: column] = matrix[row][column];
		}
		return new MatrixDeterminantCalculator(minorMatrix);
	}
}