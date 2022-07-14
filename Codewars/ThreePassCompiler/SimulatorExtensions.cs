namespace Codewars.ThreePassCompiler;

public static class SimulatorExtensions
{
	public static int Simulate(List<string> asm, int[] argv)
	{
		var r0 = 0;
		var r1 = 0;
		var stack = new List<int>();
		foreach (var ins in asm)
		{
			var code = ins[..2];
			r0 = CheckArguments(argv, code, r0, ins);
			r0 = CheckOperations(code, r0, stack, ref r1);
			r0 = CheckOperators(code, r0, r1);
		}
		return r0;
	}

	private static int CheckArguments(IReadOnlyList<int> argv, string code, int r0, string ins) =>
		code switch
		{
			"IM" => int.Parse(ins[2..].Trim()),
			"AR" => argv[int.Parse(ins[2..].Trim())],
			_ => r0
		};

	private static int CheckOperations(string code, int r0, List<int> stack, ref int r1)
	{
		switch (code)
		{
		case "SW":
			(r0, r1) = (r1, r0);
			break;
		case "PU":
			stack.Add(r0);
			break;
		case "PO":
			r0 = stack[^1];
			stack.RemoveAt(stack.Count - 1);
			break;
		}
		return r0;
	}

	private static int CheckOperators(string code, int r0, int r1)
	{
		switch (code)
		{
		case "AD":
			r0 += r1;
			break;
		case "SU":
			r0 -= r1;
			break;
		case "MU":
			r0 *= r1;
			break;
		case "DI":
			r0 /= r1;
			break;
		}
		return r0;
	}
}