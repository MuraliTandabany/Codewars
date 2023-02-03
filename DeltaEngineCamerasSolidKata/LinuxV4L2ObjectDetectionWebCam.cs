namespace DeltaEngineCamerasSolidKata;

public sealed class LinuxV4L2ObjectDetectionWebCam : ObjectDetectionVideoInput
{
	public LinuxV4L2ObjectDetectionWebCam(Action<float[]> newFrame,
		VideoInputSettings? settings = null) : base(newFrame, settings)
	{
		Name = "linux floats";
		IsRunning = true;
		yoloInput = new float[3];
	}

	public string Name { get; }
	public bool IsRunning { get; }
	private readonly float[] yoloInput;
}