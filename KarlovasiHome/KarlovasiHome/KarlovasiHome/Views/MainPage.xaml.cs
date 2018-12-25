using System.Threading.Tasks;
using Android.Content;
using Android.Locations;
using Android.Provider;
using KarlovasiHome.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            Master = new MenuPage(this);
            Detail = new NavigationPage(new FeedPage());

            MasterBehavior = MasterBehavior.Popover;
        }

        public async void NavigateFromMenu(MenuItemType type)
        {
            Page page = null;
            switch (type)
            {
                case MenuItemType.Profile:
                    page = new NavigationPage(new ProfilePage());
                    break;
                case MenuItemType.Feed:
                    page = new NavigationPage(new FeedPage());
                    break;
                case MenuItemType.Map:
                    while (!App.LocationChecker.CheckLocation())
                    {
                        if (!await DisplayAlert(null, "Ενεργοποιείστε την τοποθεσίας της συσκευής σας.", "ΟΚ", "Άκυρο"))
                        {
                            return;
                        }
                    }
                    page = new NavigationPage(new MapPage());
                    break;
                case MenuItemType.Manage:
                    page = new NavigationPage(new ManagePage());
                    break;
                case MenuItemType.Favorites:
                    page = new NavigationPage(new FavoritesPage());
                    break;
            }

            if (page != null && Detail != page)
            {
                Detail = page;

                IsPresented = false;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (IsPresented)
                    IsPresented = false;
                else
                    if (await DisplayAlert(null, "Έξοδος;", "ΟΚ", "Άκυρο"))
                        await Navigation.PopModalAsync();
            });

            return true;
        }
    }
}