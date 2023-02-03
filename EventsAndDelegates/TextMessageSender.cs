namespace EventsAndDelegates;

/// <summary>
/// Optional subscriber just to unit test Notifier
/// </summary>
public sealed class TextMessageSender
{
	public void Send(PersonEventArgs personEvent) => notifiedNames.Add(personEvent.Name);
	public readonly List<string> notifiedNames = new();
}