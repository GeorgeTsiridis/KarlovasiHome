using System.Linq;

namespace KarlovasiHome.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public bool SignIn(string username, string password)
        {
            DataService.User = DataService.Users.FirstOrDefault(x => x.Username == username && x.Password == Hash(password));

            return DataService.User != null;
        }
    }
}