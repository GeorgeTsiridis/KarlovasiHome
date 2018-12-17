using System.Collections.Generic;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class MenuViewModel
    {
        public List<HomeMenuItem> MenuItems { get; set; }

        public MenuViewModel()
        {
            if (App.DataService.User.UserType == UserType.Landlord)
                MenuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Id = MenuItemType.Profile, Title="Προφίλ"},
                    new HomeMenuItem { Id = MenuItemType.Manage, Title="Διαχείρηση"}
                };
            else
                MenuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Id = MenuItemType.Profile, Title="Προφίλ"},
                    new HomeMenuItem { Id = MenuItemType.Favorites, Title="Αγαπημένα"}
                };
        }
    }
}