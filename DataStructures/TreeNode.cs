namespace DataStructure;

public sealed class TreeNode
{
	public TreeNode(int value = 0, TreeNode? left = null, TreeNode? right = null)
	{
		Left = left;
		Right = right;
		Value = value;
	}

	public int Value { get; }
	public TreeNode? Left { get; set; }
	public TreeNode? Right { get; set; }
}