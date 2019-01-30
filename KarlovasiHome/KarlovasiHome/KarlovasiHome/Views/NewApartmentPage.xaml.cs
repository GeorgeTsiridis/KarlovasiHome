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
        private readonly NewApartmentViewModel _navm;

        public NewApartmentPage()
        {
            InitializeComponent();

            _navm = (NewApartmentViewModel) BindingContext;
        }

        private async void Add_OnClicked(object sender, EventArgs e)
        {
            if (NameEntry.Text == "" ||
                AddressEntry.Text == "" ||
                PriceEntry.Text == "" ||
                FloorAreaEntry.Text == "" ||
                YearEntry.Text == "" ||
                DescriptionEntry.Text == "")
            {
                await DisplayAlert(null, "Παρακαλώ συμπληρώστε όλα τα πεδία!", "OK");
                return;
            }

            if (RadioGroup.SelectedIndex == -1)
            {
                await DisplayAlert(null, "Παρακαλώ επιλέξτε είδος δωματίου!", "OK");
                return;
            }

            var apartment = new Apartment
            {
                Name = NameEntry.Text,
                Address = AddressEntry.Text,
                Price = Convert.ToDouble(PriceEntry.Text),
                FloorArea = Convert.ToDouble(FloorAreaEntry.Text),
                Rooms = int .Parse(RoomsEntry.Text),
                Year = int.Parse(YearEntry.Text),
                Description = DescriptionEntry.Text,
                RoomType = (RoomType) RadioGroup.SelectedIndex
            };

            await _navm.AddApartment(apartment);
            await DisplayAlert(null, "Επιτυχής προσθήκη δωματίου!", "OK");

            await Navigation.PopModalAsync();
        }
    }
}