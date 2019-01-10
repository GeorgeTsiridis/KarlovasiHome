﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin;
using Xamarin.Forms;
using Plugin.CurrentActivity;

namespace KarlovasiHome.Droid
{
    [Activity(Label = "KarlovasiHome", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Forms.Init(this, bundle);

            ImageCircleRenderer.Init();
            FormsMaps.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}