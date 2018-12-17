using KarlovasiHome.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            Master = new MenuPage(this);
            Detail = new NavigationPage(new ProfilePage());
            MasterBehavior = MasterBehavior.Popover;
        }

        public void NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int) MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int) MenuItemType.Feed:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int) MenuItemType.Map:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int) MenuItemType.Manage:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int) MenuItemType.Favorites:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                
                IsPresented = false;
            }
        }
    }
}