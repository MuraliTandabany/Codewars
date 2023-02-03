namespace DeltaEngineCamerasSolidKata;

public sealed class LinuxV4L2Webcam : VideoInput
{
	public LinuxV4L2Webcam(Action<ColorImage> newFrame, VideoInputSettings? settings = null)
		: base(newFrame, settings)
	{
		Name = "linux";
		var thread = new Thread(WorkerThread) { Name = Name };
		thread.Start();
		IsRunning = true;
	}

	private string Name { get; }
	public bool IsRunning { get; private set; }
	private void WorkerThread() => NewFrame(new ColorImage());
	public override void Dispose() => IsRunning = false;
}