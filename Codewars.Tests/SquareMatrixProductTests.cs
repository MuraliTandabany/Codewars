namespace Codewars.Tests;

public sealed class SquareMatrixProductTests
{
	[Test]
	public void OneByOne() =>
		Assert.That(new SquareMatrixProduct(new[,] { { 2 } }, new[,] { { 3 } }).MatrixMultiplication(),
			Is.EqualTo(new[,] { { 6 } }));

	[Test]
	public void TwoByTwoSimple() =>
		Assert.That(
			new SquareMatrixProduct(
				new[,] { { 1, 2 }, { 3, 2 } },
				new[,] { { 3, 2 }, { 1, 1 } }).MatrixMultiplication(),
			Is.EqualTo(new[,] { { 5, 4 }, { 11, 8 } }));

	[Test]
	public void ThreeByThree() =>
		Assert.That(
			new SquareMatrixProduct(
				new[,] { { 1, 2, 3 }, { 3, 2, 1 }, { 2, 1, 3 } },
				new[,] { { 4, 5, 6 }, { 6, 5, 4 }, { 4, 6, 5 } }).MatrixMultiplication(),
			Is.EqualTo(new[,] { { 28, 33, 29 }, { 28, 31, 31 }, { 26, 33, 31 } }));
}