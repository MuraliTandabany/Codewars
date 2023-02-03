namespace DataStructure;

public static class TreeNodeExtensions
{
	public static TreeNode? InvertTree(this TreeNode? root)
	{
		if (root != null)
			(root.Left, root.Right) = (root.Right.InvertTree(), root.Left.InvertTree());
		return root;
	}

	public static int GetMaxSum(this TreeNode? root) =>
		root == null
			? 0
			: root.Value + Math.Max(root.Left.GetMaxSum(), root.Right.GetMaxSum());

	public static bool IsPerfect(this TreeNode? root) =>
		root.IsChildPerfect() && FindDepth(root?.Left) == FindDepth(root?.Right);

	private static bool IsChildPerfect(this TreeNode? root) =>
		root.IsLeafNode() || root.HasIncompleteChildren() && root?.Left.IsChildPerfect() == true &&
		root.Right?.IsChildPerfect() == true;

	private static bool IsLeafNode(this TreeNode? root) => root?.Left == null && root?.Right == null;

	private static bool HasIncompleteChildren(this TreeNode? root) =>
		(root?.Left is not null || root?.Right is null) &&
		(root?.Left is null || root.Right is not null);

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
}