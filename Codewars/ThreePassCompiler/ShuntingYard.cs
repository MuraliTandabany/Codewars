﻿namespace Codewars.ThreePassCompiler;

/// <summary>
/// Parse Expressions with operators https://en.wikipedia.org/wiki/Shunting_yard_algorithm
/// </summary>
public sealed class ShuntingYard
{
	public ShuntingYard(IEnumerable<string> tokens)
	{
		foreach (var token in tokens)
			PutTokenIntoStacks(token);
		ApplyHigherPrecedenceOperators();
	}

	private void PutTokenIntoStacks(string token)
	{
		if (token[0] == '(')
			operators.Push(token);
		else if (token[0] == ')')
			ApplyHigherPrecedenceOperators();
		else if ("+-*/".Contains(token[0]))
		{
			ApplyHigherPrecedenceOperators(GetPrecedence(token));
			operators.Push(token);
		}
		else
			Output.Push(token);
	}

	private readonly Stack<string> operators = new();
	public Stack<string> Output { get; } = new();

	private void ApplyHigherPrecedenceOperators(int precedence = 0)
	{
		while (operators.Count > 0)
		{
			if (operators.Peek() == "(")
			{
				if (precedence == 0)
					operators.Pop();
				return;
			}
			if (GetPrecedence(operators.Peek()) < precedence)
				return;
			Output.Push(operators.Pop());
		}
	}

	private static int GetPrecedence(string token) =>
		token switch
		{
			"+" => 1,
			"-" => 1,
			"*" => 2,
			"/" => 2,
			_ => throw new NotSupportedException(token) //ncrunch: no coverage
		};
}