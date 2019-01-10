using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(37.794738, 26.708397), Distance.FromMiles(0.8)))
            {
                IsShowingUser = true,
                MapType = MapType.Street
            };

            Content = map;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
//            var position = new Position(37.795954, 26.701089); // Latitude, Longitude
//            var pin = new Pin
//            {
//                Type = PinType.SearchResult,
//                Position = position,
//                Label = "custom pin",
//                Address = "custom detail info",
//
//            };
//            Map.Pins.Add(pin);
        }
    }
}