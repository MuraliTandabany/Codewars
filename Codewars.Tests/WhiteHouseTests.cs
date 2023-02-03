using System.Collections.Generic;

namespace Codewars.Tests;

public sealed class WhiteHouseTests
{
	[Test]
	public void EmptyHouse() =>
		Assert.That(
			new WhiteHouse(new[]
			{
				"########".ToCharArray(),
				"#      #".ToCharArray(),
				"#      #".ToCharArray(),
				"########".ToCharArray()
			}).IsPotusAlone, Is.True);

	[TestCaseSource(nameof(PotusAloneHouseCases))]
	public void IsPotusAlone(char[][] map) =>
		Assert.That(new WhiteHouse(map).IsPotusAlone, Is.True);

	// ncrunch: no coverage start
	public static IEnumerable<char[][]> PotusAloneHouseCases() =>
		new[]
		{
			new[]
			{
				"########".ToCharArray(),
				"#      #".ToCharArray(),
				"#  X   #".ToCharArray(),
				"########".ToCharArray()
			},
			new[]
			{
				"  o     ".ToCharArray(),
				"########".ToCharArray(),
				"#      #".ToCharArray(),
				"#  X   #".ToCharArray(),
				"########".ToCharArray()
			},
			new[]
			{
				"  o                o        #######".ToCharArray(),
				"###############    o        #     #".ToCharArray(),
				"#             #        o    #     #".ToCharArray(),
				"#  X          ###############     #".ToCharArray(),
				"#                                 #".ToCharArray(),
				"###################################".ToCharArray()
			},
			new[]
			{
				"#################             ".ToCharArray(),
				"#               #   o         ".ToCharArray(),
				"#          ######        o    ".ToCharArray(),
				"####       #                  ".ToCharArray(),
				"   #       ###################".ToCharArray(),
				"   #                         #".ToCharArray(),
				"   #                  X      #".ToCharArray(),
				"   ###########################".ToCharArray()
			},
			new[]
			{
				"                                ".ToCharArray(),
				"  ############                  ".ToCharArray(),
				"  #          #                  ".ToCharArray(),
				"  #   o      #      ############".ToCharArray(),
				"  #          #      #          #".ToCharArray(),
				"  ############      #     X    #".ToCharArray(),
				"                    #          #".ToCharArray(),
				"                    ############".ToCharArray(),
				"                                ".ToCharArray(),
				"                                ".ToCharArray()
			}
		}; // ncrunch: no coverage end

	[TestCaseSource(nameof(PotusNotAloneHouseCases))]
	public void IsPotusNotAlone(char[][] map) =>
		Assert.That(new WhiteHouse(map).IsPotusAlone, Is.False);

	// ncrunch: no coverage start
	public static IEnumerable<char[][]> PotusNotAloneHouseCases() =>
		new[]
		{
			new[]
			{
				"########".ToCharArray(),
				"#  o   #".ToCharArray(),
				"#  X   #".ToCharArray(),
				"########".ToCharArray()
			},
			new[]
			{
				"#################             ".ToCharArray(),
				"#    o          #   o         ".ToCharArray(),
				"#          ######        o    ".ToCharArray(),
				"####       #                  ".ToCharArray(),
				"   #       ###################".ToCharArray(),
				"   #                         #".ToCharArray(),
				"   #                  X      #".ToCharArray(),
				"   ###########################".ToCharArray()
			}
		}; // ncrunch: no coverage end
}