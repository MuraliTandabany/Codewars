namespace DeltaEngineCamerasSolidKata;

/// <summary>
/// Video source any DirectShow supported device, e.g. USB webcam, frame grabber, capture board
/// </summary>
public sealed class Webcam : VideoInput
{
	public Webcam(Action<ColorImage> newFrame, VideoInputSettings? settings = null) : base(newFrame,
		settings)
	{
		deviceId = "first";
		thread = new Thread(() => { }) { Name = deviceId };
		IsRunning = true;
		thread.Start();
		shouldWake.Set();
	}

	// ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
	private readonly string deviceId;
	// ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
	public bool IsRunning { get; private set; }
	private readonly Thread thread;
	private readonly AutoResetEvent shouldWake = new(false);

	private void Dispose(bool disposing)
	{
		if (IsDisposed)
			return;
		IsDisposed = true;
		if (!disposing)
			return;
		thread.Join();
		IsRunning = false;
		shouldWake.Close();
	}

	private bool IsDisposed { get; set; }
	public override void Dispose() => Dispose(true);
}