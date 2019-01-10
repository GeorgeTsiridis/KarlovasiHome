using KarlovasiHome.Models;
using KarlovasiHome.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KarlovasiHome.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KarlovasiHome
{
    public partial class App : Application
    {
        public static DataService DataService { get; set; }

        public App()
        {
            InitializeComponent();

            DataService = new DataService();

            MainPage = new SignInPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}