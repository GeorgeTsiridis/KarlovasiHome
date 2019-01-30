using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class NewApartmentViewModel : BaseViewModel
    {
        public Dictionary<int, string> RadioButtons { get; set; }

        public NewApartmentViewModel()
        {
            RadioButtons = new Dictionary<int, string>
            {
                {0, "Γκαρσονιέρα"},
                {1, "Δυάρι"},
                {2, "Τριάρι"},
                {3, "Άλλο"}
            };
        }

        public async Task AddApartment(Apartment apartment)
        {
            Loading = true;

            apartment.Id = Guid.NewGuid().ToString();
            apartment.OwnerId = DataService.User.Id;

            await DataService.SyncApartments.InsertAsync(apartment);
            DataService.Apartments.Add(apartment);

            Loading = false;
        }
    }
}