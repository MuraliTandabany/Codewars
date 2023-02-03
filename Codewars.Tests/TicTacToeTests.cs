using System.Collections.Generic;

namespace Codewars.Tests;

public sealed class TicTacToeTests
{
	[TestCaseSource(nameof(TicTacToeTestCases))]
	public void CurrentState(int[,] board, int expected) =>
		Assert.That(new TicTacToe(board).CurrentState, Is.EqualTo(expected));

	// ncrunch: no coverage start
	public static IEnumerable<TestCaseData> TicTacToeTestCases()
	{
		yield return new TestCaseData(new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }, -1);
		yield return new TestCaseData(new[,] { { 0, 1, 0 }, { 1, 0, 0 }, { 0, 0, 2 } }, -1);
		yield return new TestCaseData(new[,] { { 2, 0, 0 }, { 1, 1, 1 }, { 2, 0, 2 } }, 1);
		yield return new TestCaseData(new[,] { { 2, 0, 0 }, { 1, 1, 1 }, { 2, 0, 2 } }, 1);
		yield return new TestCaseData(new[,] { { 2, 0, 1 }, { 0, 1, 0 }, { 1, 0, 2 } }, 1);
		yield return new TestCaseData(new[,] { { 2, 0, 1 }, { 0, 2, 0 }, { 1, 0, 2 } }, 2);
		yield return new TestCaseData(new[,] { { 2, 2, 2 }, { 0, 0, 0 }, { 1, 0, 1 } }, 2);
		yield return new TestCaseData(new[,] { { 2, 1, 1 }, { 1, 2, 2 }, { 2, 1, 1 } }, 0);
	} // ncrunch: no coverage end
}