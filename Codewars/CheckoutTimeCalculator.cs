namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/57b06f90e298a7b53d000a86
/// </summary>
public sealed class CheckoutTimeCalculator
{
	public CheckoutTimeCalculator(int[] customerQueue, int numberOfCounters)
	{
		this.customerQueue = customerQueue;
		this.numberOfCounters = numberOfCounters;
	}

	private readonly int[] customerQueue;
	private readonly int numberOfCounters;

	public int Calculate()
	{
		var countersWithCustomer = new int[numberOfCounters];
		var minimumCounterIndex = 0;
		for (var index = 0; index < customerQueue.Length; index++)
			if (index < numberOfCounters)
			{
				if (customerQueue[index] < countersWithCustomer[minimumCounterIndex])
					minimumCounterIndex = index;
				countersWithCustomer[index] = customerQueue[index];
			}
			else
			{
				countersWithCustomer[minimumCounterIndex] += customerQueue[index];
				minimumCounterIndex = Array.IndexOf(countersWithCustomer, countersWithCustomer.Min());
			}
		return countersWithCustomer.Max();
	}
}