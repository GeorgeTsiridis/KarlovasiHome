using System;
using KarlovasiHome.Models;
using KarlovasiHome.Services;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAppartmentPage : ContentPage
    {
        private NewApartmentViewModel _navm;

        public NewAppartmentPage()
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