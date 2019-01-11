using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        private ObservableCollection<Apartment> _apartments;

        public FavoritesViewModel()
        {
            Apartments = new ObservableCollection<Apartment>(DataService.Apartments.Where(x => x.IsFavorite));
            foreach (var apartment in Apartments)
            {
                var user = DataService.Users.First(x => x.Id == apartment.OwnerId);
                apartment.Phone = user.Phone;
                apartment.OwnerName = user.FirstName + " " + user.LastName;
            }
        }

        public async Task ManageFavorite(Apartment apartment)
        {
            Loading = true;

            if (apartment.IsFavorite)
            {
                apartment.IsFavorite = false;

                var favorite = DataService.Favorites.FirstOrDefault(x => x.ApartmentId == apartment.Id);
                await DataService.SyncFavorites.DeleteAsync(favorite);
                DataService.Favorites.Remove(favorite);
                Apartments.Remove(apartment);
            }
            else
            {
                apartment.IsFavorite = true;

                var favorite = new Favorite
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = DataService.User.Id,
                    ApartmentId = apartment.Id
                };

                await DataService.SyncFavorites.InsertAsync(favorite);
                DataService.Favorites.Add(favorite);
            }

            await DataService.SyncApartments.UpdateAsync(apartment);

            Loading = false;
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