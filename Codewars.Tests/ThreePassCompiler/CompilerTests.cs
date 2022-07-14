using System;
using System.Linq;
using Codewars.ThreePassCompiler;

namespace Codewars.Tests.ThreePassCompiler;

public class CompilerTests
{
	[SetUp]
	public void CreateCompiler() => compiler = new Compiler();

	private Compiler compiler = null!;

	[TestCase("")]
	[TestCase(" ")]
	[TestCase("$%%")]
	[TestCase("Hello")]
	[TestCase("[ a b")]
	[TestCase("[ b ] a")]
	public void InvalidProgram(string program) =>
		Assert.That(() => compiler.GenerateAst(program),
			Throws.InstanceOf<Compiler.InvalidProgram>()!.Or.InstanceOf<ArgumentException>()!);

	[TestCase("[ ] 5")]
	[TestCase("[ a ] a", "a")]
	[TestCase("[ a b ] a + b", "a", "b")]
	[TestCase("[ a b text ] a + b", "a", "b", "text")]
	public void ParseArguments(string program, params string[] expectedArguments)
	{
		compiler.GenerateAst(program);
		Assert.That(compiler.Arguments, Is.EqualTo(expectedArguments));
	}

	[TestCase("[ a ] a", "UnaryOperator { Operator = arg, Number = 0 }")]
	[TestCase("[ a b ] a*b", "BinaryOperator { Operator = *, Left = UnaryOperator { Operator = arg, Number = 0 }, Right = UnaryOperator { Operator = arg, Number = 1 } }")]
	[TestCase("[ a b ] a*a + b*b", "BinaryOperator { Operator = +, Left = BinaryOperator { Operator = *, Left = UnaryOperator { Operator = arg, Number = 0 }, Right = UnaryOperator { Operator = arg, Number = 0 } }, Right = BinaryOperator { Operator = *, Left = UnaryOperator { Operator = arg, Number = 1 }, Right = UnaryOperator { Operator = arg, Number = 1 } } }")]
	[TestCase("[ first second ] (first + second) / 2", "BinaryOperator { Operator = /, Left = BinaryOperator { Operator = +, Left = UnaryOperator { Operator = arg, Number = 0 }, Right = UnaryOperator { Operator = arg, Number = 1 } }, Right = UnaryOperator { Operator = imm, Number = 2 } }")]
	public void SimpleProgram(string program, string expectedAstText) =>
		Assert.That(compiler.GenerateAst(program).ToString(), Is.EqualTo(expectedAstText));

	[TestCase("[ ] 5", 5)]
	[TestCase("[ ] 5 * 2", 10)]
	[TestCase("[ ] (2 + 3) / 5", 1)]
	[TestCase("[ ] (2 + 3) * (5 - 3)", 10)]
	public void OptimizeUnary(string program, int expectedNumber) =>
		Assert.That(compiler.Optimize(compiler.GenerateAst(program)).ToString(),
			Is.EqualTo("UnaryOperator { Operator = imm, Number = " + expectedNumber + " }"));

	[TestCase("[ a ] a * 2")]
	public void OptimizeBinary(string program) =>
		Assert.That(compiler.Optimize(compiler.GenerateAst(program)).ToString(),
			Is.EqualTo("BinaryOperator { Operator = *, Left = UnaryOperator { Operator = arg, Number = 0 }, Right = UnaryOperator { Operator = imm, Number = 2 } }"));

	[TestCase("[ a ] 5 + 3 + 3 - a")]
	public void OptimizeMultipleBinary(string program) =>
		Assert.That(compiler.Optimize(compiler.GenerateAst(program)).ToString(),
			Is.EqualTo("BinaryOperator { Operator = -, Left = UnaryOperator { Operator = imm, Number = 11 }, Right = UnaryOperator { Operator = arg, Number = 0 } }"), string.Join(", ", compiler.Optimize(compiler.GenerateAst(program))));

	[Test]
	public void GenerateAssembly()
	{
		var assemblyCode =
			compiler.GenerateAssembly(compiler.Optimize(compiler.GenerateAst("[ a ] 5 + 3 - 3 / a")));
		Assert.That(string.Join(", ", assemblyCode),
			Is.EqualTo("IM 8, PU, IM 3, PU, AR 0, PU, PO , SW, PO, DI, PU, PO , SW, PO, SU, PU"));
	}

	[Test]
	public void SimulateSimple()
	{
		var assemblyCode =
			compiler.GenerateAssembly(compiler.Optimize(compiler.GenerateAst("[ a b ] a + b")));
		var result = SimulatorExtensions.Simulate(assemblyCode.ToList(), new[] { 2, 3 });
		Assert.That(result, Is.EqualTo(5));
	}

	[Test]
	public void SimulatePythagoras()
	{
		var assemblyCode =
			compiler.GenerateAssembly(compiler.Optimize(compiler.GenerateAst("[ a b ] a * a + b * b")));
		var result = SimulatorExtensions.Simulate(assemblyCode.ToList(), new[] { 2, 3 });
		Assert.That(result, Is.EqualTo(13));
	}

	[Test]
	public void SimulateKataProgram()
	{
		var ast = compiler.GenerateAst("[ x y z ] ( 2*3*x + 5*y - 3*z ) / (1 + 3 + 2*2)");
		Console.WriteLine(ast);
		var assemblyCode =
			compiler.GenerateAssembly(compiler.Optimize(ast));
		var result = SimulatorExtensions.Simulate(assemblyCode.ToList(), new[] { 4, 8, 16 });
		Assert.That(result, Is.EqualTo(2));
	}
}