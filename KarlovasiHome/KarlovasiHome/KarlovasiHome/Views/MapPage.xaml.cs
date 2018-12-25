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
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var position = new Position(37.795954, 26.701089); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.SearchResult,
                Position = position,
                Label = "custom pin",
                Address = "custom detail info",

            };
            Map.Pins.Add(pin);
        }
    }
}