namespace Codewars.Tests;

public sealed class CommandExecutingRobotTests
{
	[TestCase(new[] { 4, 4, 3 }, new[] { 4, 1 })]
	[TestCase(new[] { 4, 4, 3, 2, 2, 3 }, new[] { 5, 3 })]
	public void Walk(int[] commands, int[] destinationPoint)
	{
		var commandExecutingRobot = new CommandExecutingRobot(commands);
		commandExecutingRobot.Walk();
		Assert.That(commandExecutingRobot.CurrentPosition,
			Is.EqualTo(new Point(destinationPoint[0], destinationPoint[1])));
	}

	[TestCase(new[] { 4, 4, 3, 2, 2, 3 })]
	[TestCase(new[] { 7, 5, 4, 5, 2, 3 })]
	[TestCase(new[] { 11, 8, 6, 6, 4, 3, 7, 2, 1 })]
	[TestCase(new[] { 5, 5, 5, 5 })]
	[TestCase(new[] { 7, 5, 4, 5, 2, 3 })]
	[TestCase(new[] { 4, 4, 3, 2, 2, 3 })]
	[TestCase(new[] { 3, 3, 4, 4, 2, 2 })]
	[TestCase(new[] { 11, 8, 6, 6, 4, 3, 7, 2, 1 })]
	[TestCase(new[] { -1, -1, -1, -1 })]
	[TestCase(new[] { 5, 5, -2, -6, -1, -4, 1 })]
	public void HasVisitedTwice(int[] commands)
	{
		var commandExecutingRobot = new CommandExecutingRobot(commands);
		commandExecutingRobot.Walk();
		Assert.That(commandExecutingRobot.HasVisitedAnyPointTwice, Is.True);
	}

	[TestCase(new[] { 10, 3, 10, 2, 5, 1, 2 })]
	[TestCase(new[] { 5, -5, -5, -4 })]
	[TestCase(new[] { 5, 5, -2, -6, -1, -4 })]
	[TestCase(new[] { 5, -2, 2, -1, -3, 2, -1 })]
	public void NotVisitedTwice(int[] commands)
	{
		var commandExecutingRobot = new CommandExecutingRobot(commands);
		commandExecutingRobot.Walk();
		Assert.That(commandExecutingRobot.HasVisitedAnyPointTwice, Is.False);
	}
}