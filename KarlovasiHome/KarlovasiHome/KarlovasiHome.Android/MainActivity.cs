using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using KarlovasiHome.Models;
using Xamarin.Forms;

namespace KarlovasiHome.Droid
{
    [Activity(Label = "KarlovasiHome", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ILocationCheck
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            ImageCircleRenderer.Init();

            App.Init(this);
            LoadApplication(new App());
        }

        public bool CheckLocation()
        {
            LocationManager locationManager = (LocationManager) Forms.Context.GetSystemService(LocationService);

            return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }
    }
}