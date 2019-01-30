namespace KarlovasiHome.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private bool _enabled;

        public ProfileViewModel()
        {
            Loading = false;
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
    }
}