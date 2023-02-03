namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/525caa5c1bf619d28c000335/train/csharp
/// </summary>
public sealed record TicTacToe(int[,] Board)
{
	public int CurrentState()
	{
		for (var player = 1; player <= 2; player++)
		{
			for (var row = 0; row < 3; row++)
				if (HasWinnerInRows(row, player) || HasWinnerInColumns(row, player))
					return player;
			if (HasWonDiagonally(player))
				return player;
		}
		return HasEmptySpots()
			? -1
			: 0;
	}

	private bool HasWinnerInRows(int row, int player) =>
		Board[row, 0] == player && Board[row, 1] == player && Board[row, 2] == player;

	private bool HasWinnerInColumns(int row, int player) =>
		Board[0, row] == player && Board[1, row] == player && Board[2, row] == player;

	private bool HasWonDiagonally(int player) =>
		Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player ||
		Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player;

	private bool HasEmptySpots()
	{
		for (var row = 0; row < 3; row++)
		for (var column = 0; column < 3; column++)
			if (Board[row, column] == 0)
				return true;
		return false;
	}
}