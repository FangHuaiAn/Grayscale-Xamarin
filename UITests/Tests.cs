using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GrayscaleTime.UITests
{
	//[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);

		}

		[Test]
		public void AppLaunches ()
		{
			app.Screenshot ("First screen.");

			app.Repl ();
		}


		[Test]
		public void Tap_Grayscale()
		{
			Func<AppQuery, AppQuery> btnGrayscale = e => e.Marked("Grayscale");
			app.Tap (btnGrayscale);


			Func<AppQuery, AppQuery> lbScale = e => e.Class("UILabel");

			AppResult[] results = app.WaitForElement (lbScale);

			Assert.IsTrue (results.Any() );

			var label = results.First ();

			Assert.IsTrue (label.Label.StartsWith(@"tick:"));
		}
	}
}

