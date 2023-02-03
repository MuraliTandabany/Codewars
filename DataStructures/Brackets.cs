namespace DataStructure;

/// <summary>
/// https://www.codewars.com/kata/5277c8a221e209d3f6000b56/train/csharp
/// </summary>
public sealed record Brackets(string Input)
{
	public bool IsValid()
	{
		var stack = new Stack<char>();
		foreach (var character in Input)
			if (stack.Count > 0 && bracketsMap.ContainsKey(stack.Peek()) &&
				bracketsMap[stack.Peek()] == character)
				stack.Pop();
			else
				stack.Push(character);
		return stack.Count == 0;
	}

	private readonly Dictionary<char, char> bracketsMap =
		new() { { '(', ')' }, { '{', '}' }, { '[', ']' } };
}