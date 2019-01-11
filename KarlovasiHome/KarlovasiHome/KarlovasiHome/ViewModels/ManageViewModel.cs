using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task ManageAvailability(Apartment apartment)
        {
            Loading = true;

            apartment.IsAvailable = !apartment.IsAvailable;
            await DataService.SyncApartments.UpdateAsync(apartment);
            DataService.Apartments.Remove(apartment);
            DataService.Apartments.Add(apartment);

            Loading = false;
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