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
            Detail = new NavigationPage(new ProfilePage());

            MasterBehavior = MasterBehavior.Popover;
        }

        public void NavigateFromMenu(MenuItemType type)
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
    }
}