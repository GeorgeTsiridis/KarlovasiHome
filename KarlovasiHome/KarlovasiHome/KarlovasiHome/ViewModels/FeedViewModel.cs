using System.Collections.ObjectModel;
using System.Linq;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private ObservableCollection<Apartment> _apartments;

        public FeedViewModel()
        {
            Apartments = new ObservableCollection<Apartment>(DataService.Apartments.Where(x => x.IsAvailable));
            foreach (var apartment in Apartments)
            {
                var user = DataService.Users.First(x => x.Id == apartment.OwnerId);
                apartment.Phone = user.Phone;
                apartment.OwnerName = user.FirstName + " " + user.LastName;
            }
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