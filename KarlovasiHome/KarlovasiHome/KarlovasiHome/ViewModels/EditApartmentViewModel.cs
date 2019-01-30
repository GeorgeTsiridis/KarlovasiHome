using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class EditApartmentViewModel : BaseViewModel
    {
        private bool _enabled;
        private Apartment _apartment;

        public EditApartmentViewModel()
        {
            Enabled = false;
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }

        public Apartment Apartment
        {
            get { return _apartment; }
            set
            {
                _apartment = value;
                OnPropertyChanged(nameof(Apartment));
            }
        }
    }
}