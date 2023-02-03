using System.Net;

namespace Codewars;

/// <summary>
/// https://www.codewars.com/kata/526989a41034285187000de4/csharp
/// </summary>
public sealed record IpAddressCounter(string Start, string End)
{
	public long GetAddressCountBetweenIps() =>
		Start.Equals(End)
			? 0
			: ConvertFromIpAddressToInteger(End) - ConvertFromIpAddressToInteger(Start);

	private static uint ConvertFromIpAddressToInteger(string ipAddress)
	{
		var bytes = IPAddress.Parse(ipAddress).GetAddressBytes();
		if (BitConverter.IsLittleEndian)
			Array.Reverse(bytes);
		return BitConverter.ToUInt32(bytes, 0);
	}
}