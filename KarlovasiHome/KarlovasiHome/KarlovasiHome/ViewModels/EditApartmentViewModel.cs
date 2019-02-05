using System;
using System.Threading.Tasks;
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

        public async Task DeleteApartment()
        {
            Loading = true;

            try
            {
                foreach (var favorite in await DataService.SyncFavorites.Where(x => x.ApartmentId == Apartment.Id).ToListAsync())
                    await DataService.SyncFavorites.DeleteAsync(favorite);
                DataService.Favorites.RemoveAll(x => x.ApartmentId == Apartment.Id);

                await DataService.SyncApartments.DeleteAsync(Apartment);
                DataService.Apartments.Remove(Apartment);
            }
            catch (Exception e)
            {
                
            }

            Loading = false;
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