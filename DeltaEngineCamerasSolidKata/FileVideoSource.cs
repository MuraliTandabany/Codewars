namespace DeltaEngineCamerasSolidKata;

public sealed class FileVideoSource : VideoInput
{
	public FileVideoSource(string fileName, Action<ColorImage> newFrame,
		VideoInputSettings? settings = null) : base(newFrame, settings)
	{
		Source = fileName;
		Start();
	}

	private string Source { get; }

	private void Start()
	{
		if (string.IsNullOrEmpty(Source))
			throw new ArgumentException("Video source is not specified");
		thread = new Thread(() => { }) { Name = Source };
		thread.Start();
	}

	private Thread? thread;
	public override void Dispose() { }
}