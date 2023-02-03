namespace DataStructure;

public sealed class LinkedListAnalyzer
{
	public int GetLoopCount(LinkedListNode linkedListNode)
	{
		while (nodes.TryAdd(linkedListNode, nodes.Count))
			if (linkedListNode.Next != null)
				linkedListNode = linkedListNode.Next;
		return nodes.Count - nodes[linkedListNode];
	}

	private readonly Dictionary<LinkedListNode, int> nodes = new();
}