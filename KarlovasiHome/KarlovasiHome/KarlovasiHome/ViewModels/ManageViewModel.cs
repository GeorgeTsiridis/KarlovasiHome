using System.Collections.Generic;
using KarlovasiHome.Models;

namespace KarlovasiHome.ViewModels
{
    public class ManageViewModel : BaseViewModel
    {
        public List<Apartment> Apartments { get; set; }

        public ManageViewModel()
        {
           
        }
    }
}