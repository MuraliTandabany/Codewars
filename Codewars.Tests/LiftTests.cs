using System;

namespace Codewars.Tests;

public sealed class LiftTests
{
	[Test]
	public void NoWaitingQueue() =>
		Assert.That(new Lift(new int[][] { }, 1).GetVisitedFloors(), Is.EqualTo(new int[1]));

	[Test]
	public void EmptyBuilding()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 5).GetVisitedFloors(), new int[1]);
	}

	private static void VisitExpectedFloors(int[] result, int[] expected) =>
		Assert.That(result, Is.EqualTo(expected),
			"Expected: " + string.Join(",", expected) + "\n" + "  Actual:   " +
			string.Join(",", result));

	[Test]
	public void EnterAllFromGroundFloor()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      new[] { 1, 2, 3, 4 },
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 4).GetVisitedFloors(), new[] { 0, 1, 2, 3, 4, 0 });
	}

	[Test]
	public void MoveUp()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      Array.Empty<int>(),
      new[] { 5, 5, 5 },
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 5).GetVisitedFloors(), new[] { 0, 2, 5, 0 });
	}

	[Test]
	public void MoveFromGroundAndPickupOneThenGoToRequiredLevel()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      new[] { 2 },
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 1).GetVisitedFloors(), new[] { 0, 1, 2, 0 });
	}

	[Test]
	public void MoveUpWithLimitedCapacity()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      new[] { 3, 4, 5 },
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 3).GetVisitedFloors(), new[] { 0, 1, 3, 4, 5, 0 });
	}

	[Test]
	public void MoveDown()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      Array.Empty<int>(),
      new[] { 1, 1 },
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>(),
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 5).GetVisitedFloors(), new[] { 0, 2, 1, 0 });
	}

	[Test]
	public void MoveUpAndUp()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      new[] { 3 },
      new[] { 4 },
      Array.Empty<int>(),
      new[] { 5 },
      Array.Empty<int>(),
      Array.Empty<int>()
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 6).GetVisitedFloors(), new[] { 0, 1, 2, 3, 4, 5, 0 });
	}

	[Test]
	public void MoveUpAndMoveDown()
	{
    // @formatter:off
    int[][] floorsQueues =
    {
      Array.Empty<int>(),
      new int[1],
      Array.Empty<int>(),
      Array.Empty<int>(),
      new[] { 2 },
      new[] { 3 }
    };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 5).GetVisitedFloors(), new[] { 0, 5, 4, 3, 2, 1, 0 });
	}

	[Test]
	public void AnotherRandomBuilding()
	{
		// @formatter:off
		int[][] floorsQueues =
		{
			 new[] { 1 },
			 new[] { 2, 2, 0 },
			 Array.Empty<int>()
		 };
		// @formatter:on
		VisitExpectedFloors(new Lift(floorsQueues, 3).GetVisitedFloors(), new[] { 0, 1, 2, 1, 0 });
	}
}