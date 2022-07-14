namespace Codewars;

public sealed class TreeNode
{
	public TreeNode(TreeNode? left = null, TreeNode? right = null, int value = 0)
	{
		Left = left;
		Right = right;
		Value = value;
	}

	public TreeNode? Left { get; set; }
	public TreeNode? Right { get; set; }
	private int Value { get; }
	public bool IsPerfect() => IsChildPerfect() && FindDepth(Left) == FindDepth(Right);

	private bool IsChildPerfect() =>
		IsLeafNode() || HasIncompleteChildren() && Left?.IsChildPerfect() == true &&
		Right?.IsChildPerfect() == true;

	private bool HasIncompleteChildren() =>
		(Left is not null || Right is null) &&
		(Left is null || Right is not null);

	private bool IsLeafNode() => Left == null && Right == null;

	private static int FindDepth(TreeNode? root, int depth = 0)
	{
		while (true)
		{
			if (root?.Left == null && root?.Right == null)
				return ++depth;
			root = root.Left;
			depth++;
		}
	}

	public int MaxSum => GetMaxSum(this);

	private static int GetMaxSum(TreeNode? root) =>
		root == null
			? 0
			: root.Value + Math.Max(GetMaxSum(root.Left), GetMaxSum(root.Right));
}