namespace Codewars.Tests;

/// <summary>
/// TreeNode IsPerfect Kata - https://www.codewars.com/kata/57dd79bff6df9b103b00010f
/// </summary>
public sealed class TreeNodeTests
{
	[Test]
	public void NodeWithChildrenIsPerfect() =>
		Assert.That(new TreeNode(new TreeNode(), new TreeNode()).IsPerfect(), Is.EqualTo(true));

	[Test]
	public void NodeWithSingleChildIsNotPerfect() => Assert.That(new TreeNode(new TreeNode()).IsPerfect(), Is.EqualTo(false));

	[Test]
	public void ValidTwoDepthTreeIsPerfect()
	{
		var left = new TreeNode(new TreeNode(), new TreeNode());
		var right = new TreeNode(new TreeNode(), new TreeNode());
		Assert.That(new TreeNode(left, right).IsPerfect(), Is.EqualTo(true));
	}

	[Test]
	public void InvalidTwoDepthTreeIsNotPerfect()
	{
		var left = new TreeNode();
		var right = new TreeNode(new TreeNode(), new TreeNode());
		Assert.That(new TreeNode(left, right).IsPerfect(), Is.EqualTo(false));
	}

	[Test]
	public void InvalidTwoDepthTreeWithRightLeafIsNotPerfect()
	{
		var left = new TreeNode(new TreeNode());
		var right = new TreeNode(null, new TreeNode());
		Assert.That(new TreeNode(left, right).IsPerfect(), Is.EqualTo(false));
	}

	[Test]
	public void UnFullBalancedTreeShouldNotBePerfect()
	{
		var left = new TreeNode(new TreeNode(new TreeNode()));
		var right = new TreeNode(new TreeNode());
		Assert.That(new TreeNode(left, right).IsPerfect(), Is.EqualTo(false));
	}

	[TestCase(10)]
	[TestCase(31)]
	[TestCase(32)]
	public void CreateBrokenBigTreeWithManyNodesDeep(int depth) =>
		Assert.That(CreateNodes(depth)!.IsPerfect(), Is.False);

	private static TreeNode? CreateNodes(int depth)
	{
		if (depth == 0)
			return null;
		var node = new TreeNode();
		var nextNodes = CreateNodes(depth - 1);
		if (nextNodes == null)
			node.Left = new TreeNode(new TreeNode(), new TreeNode());
		else
			node.Left = node.Right = nextNodes;
		// to make this much faster: node.right = CreateNodes(depth - 1);
		return node;
	}

	[Test]
	public void OneDepthTree() =>
		Assert.That(new TreeNode(new TreeNode(value: 5), new TreeNode(value: 2), 5).MaxSum,
			Is.EqualTo(10));

	[Test]
	public void TwoDepthTree()
	{
		var left = new TreeNode(new TreeNode(value: 9), new TreeNode(value: 50), -22);
		var right = new TreeNode(new TreeNode(value: 9), new TreeNode(value: 2), 11);
		Assert.That(new TreeNode(left, right, 5).MaxSum, Is.EqualTo(33));
	}

	[Test]
	public void ImperfectTree()
	{
		var left = new TreeNode(new TreeNode(value: 9),
			new TreeNode(right: new TreeNode(value: -5), value: 50), -22);
		var right = new TreeNode(new TreeNode(left: new TreeNode(value: 10), value: 9),
			new TreeNode(value: 2), 11);
		Assert.That(new TreeNode(left, right, 5).MaxSum, Is.EqualTo(35));
	}
}