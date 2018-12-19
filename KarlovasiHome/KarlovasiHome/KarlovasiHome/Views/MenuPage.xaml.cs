using System;
using KarlovasiHome.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MainPage RootPage;

        public MenuPage(MainPage rootPage)
        {
            InitializeComponent();

            RootPage = rootPage;
        }

        private void ListViewMenu_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var type = ((HomeMenuItem) e.Item).Type;
            ListViewMenu.SelectedItem = null;
            RootPage.NavigateFromMenu(type);
        }

        private void ProfileImage_OnTapped(object sender, EventArgs e)
        {
            RootPage.NavigateFromMenu(MenuItemType.Profile);
        }
    }
}