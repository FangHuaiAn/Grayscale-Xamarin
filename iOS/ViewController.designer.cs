// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace GrayscaleTime.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnGrayscale { get; set; }

		[Outlet]
		UIKit.UIButton btnReload { get; set; }

		[Outlet]
		UIKit.UIImageView imageViewDiplay { get; set; }

		[Outlet]
		UIKit.UILabel lbTime { get; set; }

		[Action ("btnGrayscaleClicked:")]
		partial void btnGrayscaleClicked (Foundation.NSObject sender);

		[Action ("btnReloadClicked:")]
		partial void btnReloadClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGrayscale != null) {
				btnGrayscale.Dispose ();
				btnGrayscale = null;
			}

			if (btnReload != null) {
				btnReload.Dispose ();
				btnReload = null;
			}

			if (imageViewDiplay != null) {
				imageViewDiplay.Dispose ();
				imageViewDiplay = null;
			}

			if (lbTime != null) {
				lbTime.Dispose ();
				lbTime = null;
			}
		}
	}
}
