using System;
using KarlovasiHome.Models;
using Plugin.Geolocator;
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
                    try
                    {
                        var locator = CrossGeolocator.Current;
                        await locator.GetPositionAsync(new TimeSpan(10000));
                        page = new NavigationPage(new MapPage());
                    }
                    catch
                    {
                        await DisplayAlert(null, "Παρακαλώ ανοίξτε την τοποθεσία στη συσκευή σας και ξαναπροσπαθήστε", "ΟΚ");
                    }
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