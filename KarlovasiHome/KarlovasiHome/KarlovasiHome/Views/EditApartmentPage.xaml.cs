using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditApartmentPage : ContentPage
    {
        private Apartment _apartment;
        private NewApartmentViewModel _navm;

        public EditApartmentPage(Apartment apartment)
        {
            InitializeComponent();

            _apartment = apartment;
            _navm = (NewApartmentViewModel) BindingContext;
        }
    }
}