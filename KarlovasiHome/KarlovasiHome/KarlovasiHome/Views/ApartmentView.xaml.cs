using System;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApartmentView : PopupPage
    {
        public ApartmentViewModel _avm;

        public ApartmentView(Apartment apartment)
        {
            InitializeComponent();

            _avm = (ApartmentViewModel) BindingContext;
            _avm.Apartment = apartment;
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var apartment = (Apartment)((Image)sender).BindingContext;
            if (apartment == null)
                return;

            await _avm.ManageFavorite(apartment);
        }

        private async void Close_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}