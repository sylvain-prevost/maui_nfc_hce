using Android.App;
using Android.OS;
using Android.Runtime;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MauiNfcHceBootStrapExample;

[Application()]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
		Platforms.Android.HostApduService.FirstTimeAppStartInitialization();
    }

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
