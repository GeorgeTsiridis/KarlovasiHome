using System.Collections.Generic;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public List<HomeMenuItem> MenuItems { get; set; }

        public MenuViewModel()
        {
            if (DataService.User.UserType == UserType.Landlord)
                MenuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Type = MenuItemType.Feed, Title="Αρχική" },
                    new HomeMenuItem { Type = MenuItemType.Map, Title="Χάρτης" },
                    new HomeMenuItem { Type = MenuItemType.Manage, Title="Διαχείρηση" },
                    new HomeMenuItem { Type = MenuItemType.Favorites, Title="Αγαπημένα" }
                };
            else
                MenuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Type = MenuItemType.Feed, Title="Αρχική" },
                    new HomeMenuItem { Type = MenuItemType.Map, Title="Χάρτης" },
                    new HomeMenuItem { Type = MenuItemType.Favorites, Title="Αγαπημένα" }
                };
        }
    }
}