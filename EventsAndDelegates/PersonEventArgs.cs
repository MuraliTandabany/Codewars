namespace EventsAndDelegates;

public sealed class PersonEventArgs : EventArgs
{
	public PersonEventArgs(string name) => Name = name;
	public string Name { get; }
}