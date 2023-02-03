namespace DataStructure.Tests;

public sealed class NodeExtensionsTests
{
	[Test]
	public void MapNullHeadNode() =>
		Assert.That(NodeExtensions.Map<string, string>(null!, x => x), Is.Null);

	[Test]
	public void MapSingleNodeReturnSameHeadNodeValue() =>
		Assert.That(new Node<int>(5).Map(n => n)?.Data, Is.EqualTo(5));

	[Test]
	public void MapSingleNodeSquareTheNumber() =>
		Assert.That(new Node<int>(6).Map(n => n * n)?.Data, Is.EqualTo(36));

	[Test]
	public void MapMultipleNodesAddACharacterToText() =>
		CompareNodeLists(new Node<string>("a", new Node<string>("b", new Node<string>("c"))).Map(n => n + "A")!,
			new Node<string>("aA", new Node<string>("bA", new Node<string>("cA"))));

	[Test]
	public void MapMultipleNodesSquareTheNumber() =>
		CompareNodeLists(new Node<int>(1, new Node<int>(2, new Node<int>(3, new Node<int>(4)))).Map(n => n * n)!,
			new Node<int>(1, new Node<int>(4, new Node<int>(9, new Node<int>(16)))));

	private static void CompareNodeLists<Any>(Node<Any> result, Node<Any> expected) =>
		Assert.That(result.ToList(), Is.EqualTo(expected.ToList()));
}