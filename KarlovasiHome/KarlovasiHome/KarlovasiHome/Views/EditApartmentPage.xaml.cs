using System;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditApartmentPage : ContentPage
    {
        private readonly EditApartmentViewModel _eavm;

        public EditApartmentPage(Apartment apartment)
        {
            InitializeComponent();

            _eavm = (EditApartmentViewModel)BindingContext;
            _eavm.Apartment = apartment;
        }

        private void Settings_OnClicked(object sender, EventArgs e)
        {
            _eavm.Enabled = !_eavm.Enabled;
        }
    }
}