namespace DataStructure.Tests;

public sealed class LinkedListAnalyzerTests
{
	[TestCase(0, 2)]
	[TestCase(1, 3)]
	[TestCase(3, 30)]
	[TestCase(3904, 1087)]
	[TestCase(3000, 1000000)]
	public void CreateChainAndConfirmLoopSize(int startPieces, int loopSize) =>
		Assert.That(
			new LinkedListAnalyzer().GetLoopCount(
				CreateNodeChainWithDanglingNodes(startPieces, loopSize)), Is.EqualTo(loopSize));

	private static LinkedListNode CreateNodeChainWithDanglingNodes(int danglingNodesCount, int chainCount)
	{
		var head = new LinkedListNode();
		var tempNode = head;
		for (var count = 0; count < danglingNodesCount; count++)
		{
			tempNode.Next = new LinkedListNode();
			tempNode = tempNode.Next;
		}
		tempNode.Next = CreateNodeChain(chainCount);
		return head;
	}

	private static LinkedListNode CreateNodeChain(int chainCount)
	{
		var head = new LinkedListNode();
		var tempNode = head;
		for (var count = 0; count < chainCount; count++)
		{
			if (count == chainCount - 1)
			{
				tempNode.Next = head;
				break;
			}
			tempNode.Next = new LinkedListNode();
			tempNode = tempNode.Next;
		}
		return head;
	}
}