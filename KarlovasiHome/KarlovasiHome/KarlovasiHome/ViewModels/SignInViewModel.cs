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
            //var favorites = DataService.Favorites.Where(x => x.UserId) = await DataService.SyncFavorites.ToListAsync();

            return DataService.User != null;
        }
    }
}