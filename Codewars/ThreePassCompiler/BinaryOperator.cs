namespace Codewars.ThreePassCompiler;

public sealed record BinaryOperator(string Operator, Ast Left, Ast Right) : Ast;