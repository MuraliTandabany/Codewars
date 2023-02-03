using Grpc.Core;

namespace RobotProvider.Services;

public sealed class RobotProviderService : Robot.RobotBase
{
	public RobotProviderService(ILogger<RobotProviderService> logger) => this.logger = logger;
	private readonly ILogger<RobotProviderService> logger;

	public override Task<GetRobotReply> GetRobots(GetRobotRequest request, ServerCallContext context)
	{
		var response = new GetRobotReply
		{
			Robots =
			{
				new RobotModel { Name = "Franka", Status = "Waiting to receive command" },
				new RobotModel { Name = "Co-bot", Status = "Not available" },
				new RobotModel { Name = "Humanoid", Status = "Executing operation" }
			}
		};
		logger.LogInformation(response.ToString());
		return Task.FromResult(response);
	}

	public override async Task GetRobotsStream(GetRobotRequest request, IServerStreamWriter<RobotModel> responseStream,
		ServerCallContext context)
	{
		var robots = new RobotModel[]
		{
			new() { Name = "Franka", Status = "Waiting to receive command" },
			new() { Name = "Co-bot", Status = "Not available" },
			new() { Name = "Humanoid", Status = "Executing operation" }
		};
		foreach (var robot in robots)
		{
			await responseStream.WriteAsync(robot);
			await Task.Delay(2000);
		}
	}
}