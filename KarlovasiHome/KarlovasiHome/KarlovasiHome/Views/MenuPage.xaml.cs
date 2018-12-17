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

            var id = (int)((HomeMenuItem) e.Item).Id;
            ListViewMenu.SelectedItem = null;
            RootPage.NavigateFromMenu(id);
        }
    }
}