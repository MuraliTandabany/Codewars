// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using RobotClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7052");
var client = new Robot.RobotClient(channel);
var reply = client.GetRobotsStream(new GetRobotRequest());
while (await reply.ResponseStream.MoveNext(CancellationToken.None))
	Console.WriteLine("Available Robots: " + reply.ResponseStream.Current);
Console.ReadKey();