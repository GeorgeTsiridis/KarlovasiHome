using System.Collections.ObjectModel;
using System.Linq;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class ManageViewModel : BaseViewModel
    {
        private ObservableCollection<Apartment> _apartments;

        public ManageViewModel()
        {
            Apartments = new ObservableCollection<Apartment>(DataService.Apartments.Where(x => x.OwnerId == DataService.User.Id));
        }

        public ObservableCollection<Apartment> Apartments
        {
            get { return _apartments; }
            set
            {
                _apartments = value;
                OnPropertyChanged(nameof(Apartments));
            }
        }
    }
}