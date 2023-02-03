namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/58a64b48586e9828df000109
/// </summary>
public sealed record CommandExecutingRobot(int[] Commands)
{
	public void Walk()
	{
		for (var index = 0; index < Commands.Length; index++)
			MoveRobot(index % 2 == 0, Commands[index], index % 4 <= 1);
	}

	private void MoveRobot(bool moveYAxis, int nextPosition, bool isDirectionForward)
	{
		if (nextPosition > 0)
			for (var i = 0; i < nextPosition; i++)
				MoveOneStep(moveYAxis, isDirectionForward, isDirectionForward);
		else
			for (var i = nextPosition; i < 0; i++)
				MoveOneStep(moveYAxis, !isDirectionForward, isDirectionForward);
	}

	private void MoveOneStep(bool moveYAxis, bool isUp, bool isRight)
	{
		if (moveYAxis)
			CurrentPosition.Y = isUp
				? ++CurrentPosition.Y
				: --CurrentPosition.Y;
		else
			CurrentPosition.X = isRight
				? ++CurrentPosition.X
				: --CurrentPosition.X;
		CheckAndAddVisitedPositions();
	}

	public Point CurrentPosition { get; } = new(0, 0);

	private void CheckAndAddVisitedPositions()
	{
		if (visitedPositions.Contains(CurrentPosition))
			HasVisitedAnyPointTwice = true;
		visitedPositions.Add(new Point(CurrentPosition.X, CurrentPosition.Y));
	}

	private readonly List<Point> visitedPositions = new() { new Point(0, 0) };
	public bool HasVisitedAnyPointTwice { get; private set; }
}