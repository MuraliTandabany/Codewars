namespace DeltaEngineCamerasSolidKata;

public abstract class ObjectDetectionVideoInput
{
	protected ObjectDetectionVideoInput(Action<float[]> newFrame, VideoInputSettings? settings)
	{
		NewFrame = newFrame;
		Settings = settings ?? new VideoInputSettings();
	}

	public Action<float[]> NewFrame { get; }
	public VideoInputSettings Settings { get; }

	protected void OnNewFrameForObjectDetection(float[] floats)
	{
		FramesReceived++;
		NewFrame(floats);
	}

	public int FramesReceived { get; protected set; }
}