using System;
using KarlovasiHome.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private Map _map;
        private readonly MapViewModel _mvm;

        public MapPage()
        {
            InitializeComponent();

            _mvm = (MapViewModel) BindingContext;

            _map = new Map(MapSpan.FromCenterAndRadius(new Position(37.794738, 26.708397), Distance.FromMiles(0.8)))
            {
                IsShowingUser = true,
                MapType = MapType.Street
            };

            foreach (var apartment in _mvm.Apartments)
            {
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(apartment.Latitude, apartment.Longitude),
                    Label = apartment.Address,
                    Address = apartment.Address
                };

                pin.Clicked += PinOnClicked;

                _map.Pins.Add(pin);
            }

            Content = _map;
        }

        private async void PinOnClicked(object sender, EventArgs e)
        {
            var pin = (Pin) sender;
            var apartment = _mvm.Apartments[_map.Pins.IndexOf(pin)];
            await Navigation.PushPopupAsync(new ApartmentView(apartment));
        }

        private void Filters_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}