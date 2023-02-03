using System.Collections.Generic;
using NUnit.Framework;

namespace EventsAndDelegates.Tests;

public sealed class PersonNameNotifierTests
{
	[Test]
	public void NotifyTextMessageSender()
	{
		var peopleList = new List<string>
		{
			"Peter",
			"Mike",
			"Peter",
			"Bob",
			"Peter",
			"Peter",
			"Bob",
			"Mike",
			"Bob",
			"Peter",
			"Peter",
			"Mike",
			"Bob"
		};
		var notifier = new PersonNameNotifier();
		var textMessageSender = new TextMessageSender();
		notifier.NameAppearedThreeTimes += textMessageSender.Send;
		notifier.CountPersonNameAndTriggerNotification(peopleList);
		Assert.That(textMessageSender.notifiedNames,
			Is.EqualTo(new List<string> { "Peter", "Bob", "Peter", "Mike" }));
	}
}