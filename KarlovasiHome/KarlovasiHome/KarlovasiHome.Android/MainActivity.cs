using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using KarlovasiHome.SQLite;

namespace KarlovasiHome.Droid
{
    [Activity(Label = "KarlovasiHome", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ISqliteManage
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            SQLitePCL.Batteries_V2.Init();
            ImageCircleRenderer.Init();

            App.Init(this);
            LoadApplication(new App());
        }

        public string DatabaseFolder()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "ToDoItemSQLite.db3");
        }
    }
}