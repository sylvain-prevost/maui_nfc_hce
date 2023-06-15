using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;

namespace MauiNfcHceBootStrapExample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{    

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnResume()
    {
        base.OnResume();        
    }

    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);        
    }
}
