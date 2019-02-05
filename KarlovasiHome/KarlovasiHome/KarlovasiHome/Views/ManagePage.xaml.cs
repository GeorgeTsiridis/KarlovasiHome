using System;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagePage : ContentPage
    {
        private ManageViewModel _mvm;

        public ManagePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new ManageViewModel();
            _mvm = (ManageViewModel)BindingContext;
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

        private async void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            var _switch = (Switch) sender;
            var apartment = (Apartment) _switch.BindingContext;
            if (apartment == null)
                return;

            if (apartment.IsAvailable == _switch.IsToggled)
                return;

            await _mvm.ManageAvailability(apartment);
        }
    }
}