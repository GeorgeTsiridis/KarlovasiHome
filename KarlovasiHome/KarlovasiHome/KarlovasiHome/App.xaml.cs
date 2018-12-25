using KarlovasiHome.Models;
using KarlovasiHome.Services;
using KarlovasiHome.SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KarlovasiHome.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KarlovasiHome
{
    public partial class App : Application
    {
        public static DataService DataService { get; set; }
        public static ISqliteManage SqliteManager { get; set; }
        public static ILocationCheck LocationChecker { get; set; }

        public App()
        {
            InitializeComponent();

            DataService = new DataService(SqliteManager.DatabaseFolder());

            MainPage = new SignInPage();
        }

        public static void Init(ISqliteManage sqliteManager, ILocationCheck locationChecker)
        {
            SqliteManager = sqliteManager;
            LocationChecker = locationChecker;
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