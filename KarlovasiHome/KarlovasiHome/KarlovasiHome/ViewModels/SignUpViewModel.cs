using System.Collections.Generic;

namespace KarlovasiHome.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public Dictionary<int, string> RadioButtons { get; set; }

        public SignUpViewModel()
        {
            RadioButtons = new Dictionary<int, string>
            {
                {0, "Landlord"},
                {1, "Tenant"}
            };
        }
    }
}