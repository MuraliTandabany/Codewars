namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/5c230f017f74a2e1c300004f/csharp
/// </summary>
public sealed record WhiteHouse(char[][] Map)
{
	public bool IsPotusAlone()
	{
		var point = new Point(0, 0);
		for (var row = 0; row < Map.Length; row++)
		for (var column = 0; column < Map[row].Length; column++)
			if (Map[row][column] == 'X')
				point = new Point(row, column);
		return HasElvesInAnyDirections(point, Map, new List<Point>());
	}

	private static bool HasElvesInAnyDirections(Point point, IReadOnlyList<char[]> house, ICollection<Point> visitedPoints)
	{
		if (visitedPoints.Contains(point))
			return true;
		visitedPoints.Add(point);
		return house[point.X][point.Y] switch
		{
			'o' => false,
			'#' => true,
			_ => HasElvesInAnyDirections(point with { X = point.X + 1 }, house, visitedPoints) &&
				HasElvesInAnyDirections(point with { X = point.X - 1 }, house, visitedPoints) &&
				HasElvesInAnyDirections(point with { Y = point.Y + 1 }, house, visitedPoints) &&
				HasElvesInAnyDirections(point with { Y = point.Y - 1 }, house, visitedPoints)
		};
	}
}