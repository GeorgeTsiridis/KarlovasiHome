using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public Dictionary<int, string> RadioButtons { get; set; }

        public SignUpViewModel()
        {
            RadioButtons = new Dictionary<int, string>
            {
                { 0, "Ιδιοκτήτης" },
                { 1, "Ενοικιαστής" }
            };
        }

        public async Task SignUp(User user)
        {
            Loading = true;

            user.Id = Guid.NewGuid().ToString();
            user.Password = Hash(user.Password);

            await DataService.SyncUsers.InsertAsync(user);
            DataService.Users.Add(user);

            Loading = false;
        }
    }
}