namespace DataStructure;

public static class NodeExtensions
{
	public static Node<OutputType>? Map<InputType, OutputType>(this Node<InputType>? head,
		Func<InputType, OutputType> function) =>
		head != null
			? new Node<OutputType>(function(head.Data), Map(head.Next, function))
			: null;

	public static List<Node<Any>> ToList<Any>(this Node<Any> head)
	{
		var nodes = new List<Node<Any>>();
		var next = head;
		while (next != null)
		{
			nodes.Add(next);
			next = next.Next!;
		}
		return nodes;
	}
}