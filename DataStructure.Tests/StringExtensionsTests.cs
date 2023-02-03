namespace DataStructure.Tests;

public sealed class StringExtensionsTests
{
	[TestCase("", "")]
	[TestCase("alphabet", "alphabet")]
	[TestCase("Alphabet", "Alphabet")]
	[TestCase("alphabet-ball", "alphabetBall")]
	[TestCase("Alphabet-ball_cat", "AlphabetBallCat")]
	[TestCase("AlphaBet_bAll", "AlphaBetBAll")]
	[TestCase("123_asd", "123Asd")]
	[TestCase("the_Stealth_Warrior", "theStealthWarrior")]
	[TestCase("The-Stealth_Warrior", "TheStealthWarrior")]
	public void ToCamelCaseSplitByHyphenAndUnderscore(string input, string expected) =>
		Assert.That(input.ToCamelCaseSplitByHyphenAndUnderscore(), Is.EqualTo(expected));
}