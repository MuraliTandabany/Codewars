namespace DeltaEngineCamerasSolidKata;

public abstract class VideoInput : IDisposable
{
	protected VideoInput(Action<ColorImage> newFrame, VideoInputSettings? settings = null)
	{
		NewFrame = newFrame;
		Settings = settings ?? new VideoInputSettings();
	}

	public Action<ColorImage> NewFrame { get; }
	public VideoInputSettings Settings { get; }

	public void OnNewFrame(ColorImage colorImage)
	{
		FramesReceived++;
		NewFrame(colorImage);
		LastImage = colorImage;
	}

	public int FramesReceived { get; protected set; }
	public ColorImage? LastImage { get; private set; }
	public abstract void Dispose();
}