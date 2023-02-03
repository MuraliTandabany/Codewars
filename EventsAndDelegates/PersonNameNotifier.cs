namespace EventsAndDelegates;

/// <summary>
/// https://www.codewars.com/kata/5790bd38671cb57f7900012f/csharp
/// </summary>
public sealed class PersonNameNotifier
{
	public void CountPersonNameAndTriggerNotification(List<string> peopleNameList)
	{
		var appearedPersonCount = new Dictionary<string, int>();
		foreach (var personName in peopleNameList)
		{
			if (appearedPersonCount.ContainsKey(personName))
				appearedPersonCount[personName] += 1;
			else
				appearedPersonCount.Add(personName, 1);
			if (appearedPersonCount[personName] % 3 == 0)
				NameAppearedThreeTimes(new PersonEventArgs(personName));
		}
	}

	public event NotifySubscribers NameAppearedThreeTimes = delegate { };
}