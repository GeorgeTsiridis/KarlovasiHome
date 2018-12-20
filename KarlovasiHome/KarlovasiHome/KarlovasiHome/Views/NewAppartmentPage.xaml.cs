using System;
using KarlovasiHome.Models;
using KarlovasiHome.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAppartmentPage : ContentPage
    {
        private DataService DataService = App.DataService;

        public NewAppartmentPage()
        {
            InitializeComponent();
        }
        
        private void SignUp_OnClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text,
                UserType = (UserType) RadioGroup.SelectedIndex
            };

            DataService.InsertUser(user);
        }
    }
}