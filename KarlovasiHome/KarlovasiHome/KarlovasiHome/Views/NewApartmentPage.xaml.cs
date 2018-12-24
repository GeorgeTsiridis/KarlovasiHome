using System;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewApartmentPage : ContentPage
    {
        private NewApartmentViewModel _navm;

        public NewApartmentPage()
        {
            InitializeComponent();

            _navm = (NewApartmentViewModel) BindingContext;
        }

        private async void Add_OnClicked(object sender, EventArgs e)
        {
            var apartment = new Apartment
            {
                OwnerId = _navm.DataService.User.Id
            };

            await _navm.DataService.InsertItem(apartment);
        }
    }
}