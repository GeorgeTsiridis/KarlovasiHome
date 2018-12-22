using System;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private SignUpViewModel _suvm;

        public SignUpPage()
        {
            InitializeComponent();

            _suvm = (SignUpViewModel) BindingContext;
        }
        
        private void SignUp_OnClicked(object sender, EventArgs e)
        {
            //checks
            //check if username exists
            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text,
                UserType = (UserType) RadioGroup.SelectedIndex
            };

            _suvm.DataService.InsertUser(user);
        }
    }
}