namespace DataStructure.Tests;

/// <summary>
/// TreeNode IsPerfect Kata - https://www.codewars.com/kata/57dd79bff6df9b103b00010f
/// </summary>
public sealed class TreeNodeTests
{
	[Test]
	public void NodeWithChildrenIsPerfect() =>
		Assert.That(new TreeNode(left: new TreeNode(), right: new TreeNode()).IsPerfect(), Is.EqualTo(true));

	[Test]
	public void NodeWithSingleChildIsNotPerfect() =>
		Assert.That(new TreeNode(left: new TreeNode()).IsPerfect(), Is.EqualTo(false));

	[Test]
	public void ValidTwoDepthTreeIsPerfect()
	{
		var left = new TreeNode(left: new TreeNode(), right: new TreeNode());
		var right = new TreeNode(left: new TreeNode(), right: new TreeNode());
		Assert.That(new TreeNode(left: left, right: right).IsPerfect(), Is.EqualTo(true));
	}

	[Test]
	public void InvalidTwoDepthTreeIsNotPerfect()
	{
		var left = new TreeNode();
		var right = new TreeNode(left: new TreeNode(), right: new TreeNode());
		Assert.That(new TreeNode(left: left, right: right).IsPerfect(), Is.EqualTo(false));
	}

	[Test]
	public void InvalidTwoDepthTreeWithRightLeafIsNotPerfect()
	{
		var left = new TreeNode(left: new TreeNode());
		var right = new TreeNode(left: null, right: new TreeNode());
		Assert.That(new TreeNode(left: left, right: right).IsPerfect(), Is.EqualTo(false));
	}

	[Test]
	public void UnFullBalancedTreeShouldNotBePerfect()
	{
		var left = new TreeNode(left: new TreeNode(left: new TreeNode()));
		var right = new TreeNode(left: new TreeNode());
		Assert.That(new TreeNode(left: left, right: right).IsPerfect(), Is.EqualTo(false));
	}

	//ncrunch: no coverage start
	[Category("Slow")]
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
			node.Left = new TreeNode(left: new TreeNode(), right: new TreeNode());
		else
			node.Left = node.Right = nextNodes;
		// to make this much faster: node.right = CreateNodes(depth - 1);
		return node;
	} //ncrunch: no coverage end

	[Test]
	public void MaxSumOneDepthTree() =>
		Assert.That(new TreeNode(5, new TreeNode(value: 5), new TreeNode(value: 2)).GetMaxSum(),
			Is.EqualTo(10));

	[Test]
	public void MaxSumTwoDepthTree()
	{
		var left = new TreeNode(-22, new TreeNode(value: 9), new TreeNode(value: 50));
		var right = new TreeNode(11, new TreeNode(value: 9), new TreeNode(value: 2));
		Assert.That(new TreeNode(5, left, right).GetMaxSum(), Is.EqualTo(33));
	}

	[Test]
	public void MaxSumImperfectTree()
	{
		var left = new TreeNode(-22, new TreeNode(value: 9), new TreeNode(value: 50, right: new TreeNode(value: -5)));
		var right = new TreeNode(11, new TreeNode(value: 9, left: new TreeNode(value: 10)), new TreeNode(value: 2));
		Assert.That(new TreeNode(5, left, right).GetMaxSum(), Is.EqualTo(35));
	}

	[Test]
	public void InvertLeafNodeTree() =>
		CompareInvertedTrees(new TreeNode(value: 4), new TreeNode(value: 4));

	[Test]
	public void InvertTree()
	{
		var left = new TreeNode(2, new TreeNode(value: 1), new TreeNode(value: 3));
		var right = new TreeNode(7, new TreeNode(value: 6), new TreeNode(value: 9));
		var expectedTree = new TreeNode(4, new TreeNode(7, new TreeNode(value: 9), new TreeNode(value: 6)), new TreeNode(2, new TreeNode(value: 3), new TreeNode(value: 1)));
		CompareInvertedTrees(new TreeNode(4, left, right).InvertTree(), expectedTree);
	}

	private static void CompareInvertedTrees(TreeNode? invertedTree, TreeNode? expectedTree)
	{
		while (true)
		{
			if (invertedTree == null && expectedTree == null)
				return;
			Assert.That(invertedTree == null && expectedTree != null || invertedTree != null && expectedTree == null, Is.False);
			Assert.That(invertedTree?.Value == expectedTree?.Value, Is.True);
			CompareInvertedTrees(invertedTree?.Left, expectedTree?.Left);
			invertedTree = invertedTree?.Right;
			expectedTree = expectedTree?.Right;
		}
	}
}