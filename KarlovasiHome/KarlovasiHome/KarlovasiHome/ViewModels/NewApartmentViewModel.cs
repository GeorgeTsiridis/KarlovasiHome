using System.Collections.Generic;

namespace KarlovasiHome.ViewModels
{
    public class NewApartmentViewModel
    {
        public Dictionary<int, string> RadioButtons { get; set; }

        public NewApartmentViewModel()
        {
            RadioButtons = new Dictionary<int, string>
            {
                {0, "Ιδιοκτήτης"},
                {1, "Ενοικιαστής"}
            };
        }
    }
}