using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
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

        public string Hash(string password)
        {
            var sb = new StringBuilder();
            foreach (var b in SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))
                sb.Append(b.ToString("x2"));
            return sb.ToString();
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