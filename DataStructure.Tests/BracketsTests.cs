namespace DataStructure.Tests;

public sealed class BracketsTests
{
	[TestCase("()", true)]
	[TestCase("(", false)]
	[TestCase("(}", false)]
	[TestCase("[({})](]", false)]
	[TestCase(")(}{][", false)]
	[TestCase("[]", true)]
	[TestCase("(){}[]", true)]
	[TestCase("{(})", false)]
	[TestCase("([)]", false)]
	[TestCase("())({}}{()][][", false)]
	[TestCase("({})[({})]", true)]
	[TestCase("({})[({]})]", false)]
	public void IsValid(string input, bool expected) =>
		Assert.That(new Brackets(input).IsValid(), Is.EqualTo(expected));
}