using AppSandboxUIKit;
using Foundation;
using Microsoft.Maui.Embedding;
using UIKit;

namespace AppSandboxCatalyst;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}
	
	MauiContext _mauiContext;

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		MauiAppBuilder builder = MauiApp.CreateBuilder();
		builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();

		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		builder.Services.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor(typeof(UIWindow), Window));
		MauiApp mauiApp = builder.Build();
		_mauiContext = new MauiContext(mauiApp.Services);
		
		// create a UIViewController with a single UILabel
		var vc = new RootSplitViewController (this._mauiContext);
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}
}
