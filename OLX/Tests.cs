using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace OLX
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}


		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("photo");
			app.Screenshot("Let's start by Tapping on the first item on the page");

			app.Tap("action_observe");
			app.Screenshot("Then we Tapped on the 'Star' Icon");

			app.Back();
			app.Screenshot("We Tapped the 'Back' Button");

			app.Tap("action_search");
			app.Screenshot("Next we Tapped on the 'Search' Icon");

			app.EnterText("microsoft");
			app.Screenshot("We entered our search, 'Microsoft'");

			app.PressEnter();
			app.Screenshot("Then we Tapped on the 'Enter' Button");

			//Thread.Sleep(8000);
			app.Tap("photo");
			app.Screenshot("We Tapped on the first Microsoft item");

			Thread.Sleep(8000);
			app.Tap(x => x.Class("android.widget.ImageView").Index(0));
			app.Screenshot("We Tapped on the main picture");

			app.SwipeRightToLeft();
			app.Screenshot("We Swiped right for more pictures");

			app.SwipeRightToLeft();
			app.Screenshot("We Swiped right for more pictures");

			app.SwipeRightToLeft();
			app.Screenshot("We Swiped right for more pictures");

			Thread.Sleep(8000);
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button");

			Thread.Sleep(8000);
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button again to return to Home Screen");

			//Thread.Sleep(30000);
			//app.Tap(x => x.Class("android.widget.ImageButton").Index(9));
			//app.Screenshot("Then we Tapped on the 'Hamburger' Button");
		}
	
	}
}
