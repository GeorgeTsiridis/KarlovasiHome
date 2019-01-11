using System.Linq;
using System.Threading.Tasks;

namespace KarlovasiHome.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public async Task<bool> SignIn(string username, string password)
        {
            DataService.User = DataService.Users.FirstOrDefault(x => x.Username == username && x.Password == Hash(password));
            DataService.Apartments = await DataService.SyncApartments.ToListAsync();
            var favorites = await DataService.SyncFavorites.ToListAsync();
            DataService.Favorites = favorites.Where(x => x.UserId == DataService.User.Id).ToList();

            foreach (var favorite in DataService.Favorites)
            {
                var apartment = DataService.Apartments.FirstOrDefault(x => x.Id == favorite.ApartmentId);

                if (apartment != null)
                    apartment.IsFavorite = true;
            }

            return DataService.User != null;
        }
    }
}