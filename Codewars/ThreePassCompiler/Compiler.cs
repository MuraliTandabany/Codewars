using System.Text.RegularExpressions;

namespace Codewars.ThreePassCompiler;

/// <summary>
/// https://www.codewars.com/kata/5265b0885fda8eac5900093b
/// </summary>
public sealed class Compiler
{
	public Ast GenerateAst(string program)
	{
		var tokens = Tokenize(program);
		Arguments = GetArguments(tokens);
		var postfix = new ShuntingYard(tokens.Skip(Arguments.Length + 2)).Output;
		var token = postfix.Pop();
		return BuildAst(token, postfix);
	}

	private static List<string> Tokenize(string input)
	{
		var matches = new Regex("\\[|\\]|[-+*/=\\(\\)]|[A-Za-z_][A-Za-z0-9_]*|[0-9]*(\\.?[0-9]+)").
			Matches(input);
		var tokens = new List<string>();
		foreach (Match m in matches)
			tokens.Add(m.Groups[0].Value);
		return tokens;
	}

	public string[] Arguments { get; private set; } = Array.Empty<string>();

	private static string[] GetArguments(IList<string> tokens)
	{
		if (tokens.Count <= 2 || tokens[0] != "[" || !tokens.Contains("]"))
			throw new InvalidProgram();
		var arguments = new List<string>();
		for (var index = 1; index < tokens.Count && tokens[index] != "]"; index++)
			arguments.Add(tokens[index]);
		return arguments.ToArray();
	}

	public class InvalidProgram : Exception { }

	private Ast BuildAst(string token, Stack<string> postfix)
	{
		if (!"+-*/".Contains(token[0]))
			return int.TryParse(token, out var number)
				? new UnaryOperator(Imm, number)
				: new UnaryOperator(Arg, GetArgumentIndex(token));
		var right = BuildAst(postfix.Pop(), postfix);
		var left = BuildAst(postfix.Pop(), postfix);
		return new BinaryOperator(token, left, right);
	}

	private int GetArgumentIndex(string name)
	{
		var argumentIndex = Array.IndexOf(Arguments, name);
		return argumentIndex < 0
			? throw new ArgumentException(name + " not found in (" + string.Join(", ", Arguments) + ")")
			: argumentIndex;
	}

	private const string Arg = "arg";
	private const string Imm = "imm";

	public Ast Optimize(Ast ast)
	{
		if (ast is not BinaryOperator binaryOperator)
			return ast;
		var binary = new BinaryOperator(binaryOperator.Operator, Optimize(binaryOperator.Left),
			Optimize(binaryOperator.Right));
		if (binary.Left is UnaryOperator { Operator: Imm } left && binary.Right is UnaryOperator
			{
				Operator: Imm
			} right)
			return new UnaryOperator(Imm, EvaluateBinary(left.Number, binaryOperator.Operator, right.Number));
		return binary;
	}

	private static int EvaluateBinary(int left, string binaryOperator, int right) =>
		binaryOperator switch
		{
			"+" => left + right,
			"-" => left - right,
			"*" => left * right,
			"/" => left / right,
			_ => throw new InvalidProgram() //ncrunch: no coverage
		};

	public IEnumerable<string> GenerateAssembly(Ast ast)
	{
		var list = new List<string>();
		if (ast is BinaryOperator binaryOperator)
		{
			list.AddRange(GenerateAssembly(binaryOperator.Left));
			list.AddRange(GenerateAssembly(binaryOperator.Right));
		}
		list.AddRange(GetOperations(ast));
		return list;
	}

	private static IEnumerable<string> GetOperations(Ast ast) =>
		ast.Operator switch
		{
			"imm" => new[] { "IM " + ((UnaryOperator)ast).Number, "PU" },
			"arg" => new[] { "AR " + ((UnaryOperator)ast).Number, "PU" },
			"+" => new[] { "PO ", "SW", "PO", "AD", "PU" },
			"-" => new[] { "PO ", "SW", "PO", "SU", "PU" },
			"*" => new[] { "PO ", "SW", "PO", "MU", "PU" },
			"/" => new[] { "PO ", "SW", "PO", "DI", "PU" },
			_ => throw new InvalidProgram() //ncrunch: no coverage
		};
}