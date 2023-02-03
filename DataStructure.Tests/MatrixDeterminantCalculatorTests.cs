namespace DataStructure.Tests;

public sealed class MatrixDeterminantCalculatorTests
{
	/// <summary>
	/// https://www.codewars.com/kata/52a382ee44408cea2500074c
	/// </summary>
	[Test]
	public void Find1By1Determinant() =>
		Assert.That(new MatrixDeterminantCalculator(new[]
		{
			new[] { 1 }
		}).Calculate(), Is.EqualTo(1));

	[Test]
	public void Find2By2Determinant() =>
		Assert.That(new MatrixDeterminantCalculator(new[]
			{
				new[] { 1, 3 },
				new[] { 2, 5 }
			}).Calculate(),
			Is.EqualTo(-1));

	[Test]
	public void Find3By3Determinant() =>
		Assert.That(new MatrixDeterminantCalculator(new[]
			{
				new[] { 2, 5, 3 },
				new[] { 1, -2, -1 },
				new[] { 1, 3, 4 }
			}).Calculate(),
			Is.EqualTo(-20));
}