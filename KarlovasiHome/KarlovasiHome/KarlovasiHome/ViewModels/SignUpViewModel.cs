using System.Collections.Generic;

namespace KarlovasiHome.ViewModels
{
    public class SignUpViewModel
    {
        public Dictionary<int, string> RadioButtons { get; set; }

        public SignUpViewModel()
        {
            RadioButtons = new Dictionary<int, string>
            {
                {0, "Ιδιοκτήτης"},
                {1, "Ενοικιαστής"}
            };
        }
    }
}