using System;
using System.Drawing;
using System.Diagnostics;
		
using UIKit;
using Foundation;
using CoreGraphics;

namespace GrayscaleTime.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{		
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UIImage imageOriginal = UIImage.FromFile( @"Images/sample.png" );

			imageViewDiplay.Image = imageOriginal;
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.	

		}

		partial void btnGrayscaleClicked (NSObject sender)
		{
			UIImage imageOriginal = UIImage.FromFile( @"Images/sample.png" );
			UIImage imageSource = UIImage.FromImage( imageOriginal.CGImage );

			Stopwatch watch = new Stopwatch();

			watch.Start();

			UIImage imageProcessed = ConvertToGrayScale( imageSource );

			watch.Stop();

			long tick = watch.ElapsedTicks;

			long milliSeconds = watch.ElapsedMilliseconds;

			watch.Reset();

			imageViewDiplay.Image = imageProcessed;

			string message = string.Format(@"tick:{0};duration:{1}", tick, milliSeconds);

			lbTime.Text = message;
		}

		partial void btnReloadClicked (NSObject sender)
		{
			UIImage imageOriginal = UIImage.FromFile( @"Images/sample.png" );

			imageViewDiplay.Image = imageOriginal;
		}

		UIImage ConvertToGrayScale (UIImage image)
		{
			RectangleF imageRect = new RectangleF (0, 0, (float)image.Size.Width, (float)image.Size.Height);
			using (var colorSpace = CGColorSpace.CreateDeviceGray ())
			using (var context = new CGBitmapContext (IntPtr.Zero, (int) imageRect.Width, (int) imageRect.Height, 8, 0, colorSpace, CGImageAlphaInfo.None)) {
				context.DrawImage (imageRect, image.CGImage);
				using (var imageRef = context.ToImage ())
					return new UIImage (imageRef);
			}
		}
	}
}
