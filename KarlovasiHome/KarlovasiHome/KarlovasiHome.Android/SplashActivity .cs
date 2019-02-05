using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace KarlovasiHome.Droid
{
    [Activity(Label = "Karlovasi Home", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        void SimulateStartup()
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}