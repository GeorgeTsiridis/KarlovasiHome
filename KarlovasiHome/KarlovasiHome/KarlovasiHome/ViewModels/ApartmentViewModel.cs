using System;
using System.Linq;
using System.Threading.Tasks;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class ApartmentViewModel : BaseViewModel
    {
        private Apartment _apartment;

        public async Task ManageFavorite(Apartment apartment)
        {
            Loading = true;

            if (apartment.IsFavorite)
            {
                apartment.IsFavorite = false;

                var favorite = DataService.Favorites.FirstOrDefault(x => x.ApartmentId == apartment.Id);
                await DataService.SyncFavorites.DeleteAsync(favorite);
                DataService.Favorites.Remove(favorite);
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