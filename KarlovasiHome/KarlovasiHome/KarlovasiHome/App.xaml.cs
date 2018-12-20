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
        public static ItemDatabase ItemDatabase { get; set; }
        public static ISqliteManage SqliteManage { get; set; }
        public static ItemController ItemController { get; set; }

        public App()
        {
            InitializeComponent();

            ItemDatabase = new ItemDatabase(SqliteManage.DatabaseFolder());
            ItemController = new ItemController();

            DataService = new DataService();

            MainPage = new SignInPage();
        }

        public static void Init(ISqliteManage sqliteManage)
        {
            SqliteManage = sqliteManage;
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