using System.Collections.Generic;

namespace KarlovasiHome.ViewModels
{
    public class NewApartmentViewModel : BaseViewModel
    {
        public Dictionary<int, string> RadioButtons { get; set; }

        public NewApartmentViewModel()
        {
            RadioButtons = new Dictionary<int, string>
            {
                {0, "Γκαρσονιέρα"},
                {1, "Δυάρι"},
                {2, "Τριάρι"},
                {3, "Άλλο"}
            };
        }
    }
}