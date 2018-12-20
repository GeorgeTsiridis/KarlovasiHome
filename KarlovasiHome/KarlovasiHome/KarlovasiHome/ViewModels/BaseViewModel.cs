using System.ComponentModel;
using System.Runtime.CompilerServices;
using KarlovasiHome.Services;

namespace KarlovasiHome.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private DataService _dataService;
            
        public BaseViewModel()
        {
            DataService = App.DataService;
        }

        public DataService DataService
        {
            get { return _dataService; }
            private set
            {
                _dataService = value;
                OnPropertyChanged(nameof(DataService));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}