namespace Codewars;

public sealed record Lift(int[][] FloorsWithPeopleQueue, int Capacity)
{
	public int[] GetVisitedFloors()
	{
		var visitedFloors = new List<int> { 0 };
		if (FloorsWithPeopleQueue.Length <= 1)
			return visitedFloors.ToArray();
		bool peopleAvailableInQueue;
		do
		{
			peopleAvailableInQueue = false;
			MoveUp(visitedFloors, ref peopleAvailableInQueue);
			MoveDown(visitedFloors, ref peopleAvailableInQueue);
		} while (peopleInLift.Count > 0 || peopleAvailableInQueue);
		if (visitedFloors.Last() != 0)
			visitedFloors.Add(0);
		if (visitedFloors.Count > 1 && visitedFloors[1] == 0)
			visitedFloors.RemoveAt(1);
		return visitedFloors.ToArray();
	}

	private readonly List<int> peopleInLift = new();

	private void MoveUp(ICollection<int> stoppingFloors, ref bool peopleAvailableInQueue)
	{
		for (floorIndex = 0; floorIndex < FloorsWithPeopleQueue.Length; floorIndex++)
			peopleAvailableInQueue = RunLiftOnce(true, stoppingFloors);
	}

	private int floorIndex;

	private bool RunLiftOnce(bool goingUp, ICollection<int> visitedFloors)
	{
		if (TryAddPeopleToLift(floorIndex, goingUp) || peopleInLift.Contains(floorIndex))
			visitedFloors.Add(floorIndex);
		peopleInLift.RemoveAll(f => f == floorIndex);
		return FloorsWithPeopleQueue[floorIndex].Length > 0;
	}

	private bool TryAddPeopleToLift(int currentFloor, bool goingUp)
	{
		var peopleAdded = 1;
		var count = FloorsWithPeopleQueue[currentFloor].Length;
		var dequeuedPeople = new List<int>();
		for (var index = 0; index < count; index++)
		{
			var getDownFloor = FloorsWithPeopleQueue[currentFloor][index];
			if ((goingUp
					? getDownFloor > currentFloor
					: getDownFloor < currentFloor) && peopleInLift.Count < Capacity)
			{
				peopleAdded++;
				peopleInLift.Add(getDownFloor);
			}
			else
			{
				dequeuedPeople.Add(getDownFloor);
			}
		}
		FloorsWithPeopleQueue[currentFloor] = dequeuedPeople.ToArray();
		return peopleAdded > 1;
	}

	private void MoveDown(ICollection<int> stoppingFloors, ref bool peopleAvailableInQueue)
	{
		for (--floorIndex; floorIndex >= 0; floorIndex--)
			if (RunLiftOnce(false, stoppingFloors))
				peopleAvailableInQueue = true; //ncrunch: no coverage
	}
}