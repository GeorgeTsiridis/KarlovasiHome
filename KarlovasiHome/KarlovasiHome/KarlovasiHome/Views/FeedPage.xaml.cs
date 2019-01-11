using System;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedPage : ContentPage
    {
        private readonly FeedViewModel _fvm;

        public FeedPage()
        {
            InitializeComponent();

            _fvm = (FeedViewModel) BindingContext;
        }

        private void ApartmentsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ApartmentsListView.SelectedItem = null;
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var apartment = (Apartment) ((Image) sender).BindingContext;
            if (apartment == null)
                return;

            await _fvm.ManageFavorite(apartment);
        }

        private void Filters_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}