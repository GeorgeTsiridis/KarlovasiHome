using System;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly MapViewModel _mvm;

        public MapPage()
        {
            InitializeComponent();

            _mvm = (MapViewModel) BindingContext;

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(37.794738, 26.708397), Distance.FromMiles(0.8)))
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
                };

                map.Pins.Add(pin);
            }

            Content = map;
        }

        private void Filters_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}