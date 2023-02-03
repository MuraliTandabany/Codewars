namespace DeltaEngineCamerasSolidKata.Tests;

[Category("Manual")]
public sealed class VideoInputTests
{
	[Test]
	public void OpenCameraFirstCameraAndSaveImage() => Assert.That(new Webcam(NewFrame), Is.Not.Null);

	private void NewFrame(ColorImage image)
	{
		Assert.That(image, Is.Not.EqualTo(lastImage!));
		image.Save("Test.jpg");
		lastImage = image;
	}

	private ColorImage? lastImage;
}