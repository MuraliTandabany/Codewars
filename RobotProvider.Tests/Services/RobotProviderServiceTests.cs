using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using RobotProvider.Services;

namespace RobotProvider.Tests.Services;

public sealed class RobotProviderServiceTests
{
	[SetUp]
	public void CreateLogger() => logger = new Logger<RobotProviderService>(new LoggerFactory());

	private ILogger<RobotProviderService> logger = null!;

	[Test]
	public async Task GetRobotsShouldReturnAllRobots() =>
		Assert.That((await new RobotProviderService(logger).GetRobots(null!, null!)).Robots!.Count,
			Is.EqualTo(3));

	[Ignore("Unable to check the response using mockStreamReader")]
	[Test]
	public async Task GetRobotsStreamShouldReturnAllRobots()
	{
		var mockStreamReader =
			new Mock<IServerStreamWriter<RobotModel>>();
		await new RobotProviderService(logger).GetRobotsStream(null!, mockStreamReader.Object,
			null!);
		Assert.That(mockStreamReader.Object, Is.EqualTo(3));
	}
}