using System.Collections.ObjectModel;
using System.Linq;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private ObservableCollection<Apartment> _apartments;

        public MapViewModel()
        {
            Apartments = new ObservableCollection<Apartment>(DataService.Apartments.Where(x => x.IsAvailable));
        }

        public ObservableCollection<Apartment> Apartments
        {
            get { return _apartments; }
            private set
            {
                _apartments = value;
                OnPropertyChanged(nameof(Apartments));
            }
        }
    }
}