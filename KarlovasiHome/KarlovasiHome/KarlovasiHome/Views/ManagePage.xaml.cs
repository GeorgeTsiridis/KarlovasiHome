using System;
using KarlovasiHome.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagePage : ContentPage
    {
        public ManagePage()
        {
            InitializeComponent();
        }

        private async void Add_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewApartmentPage());
        }

        private async void ApartmentsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ApartmentsListView.SelectedItem == null)
                return;

            var apartment = (Apartment) ApartmentsListView.SelectedItem;
            ApartmentsListView.SelectedItem = null;
            await Navigation.PushAsync(new EditApartmentPage(apartment));
        }
    }
}