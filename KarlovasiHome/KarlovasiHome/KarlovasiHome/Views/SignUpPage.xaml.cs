using System;
using System.Linq;
using KarlovasiHome.Models;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private readonly SignUpViewModel _suvm;

        public SignUpPage()
        {
            InitializeComponent();

            _suvm = (SignUpViewModel) BindingContext;
        }
        
        private async void SignUp_OnClicked(object sender, EventArgs e)
        {/*
            if (UsernameEntry.Text == "" ||
                NameEntry.Text == "" ||
                LastNameEntry.Text == "" ||
                PhoneEntry.Text == "" ||
                EmailEntry.Text == "" ||
                PasswordEntry.Text == "")
            {
                await DisplayAlert(null, "Παρακαλώ συμπληρώστε όλα τα πεδία!", "OK");
                return;
            }
            */
            if (RadioGroup.SelectedIndex == -1)
            {
                await DisplayAlert(null, "Παρακαλώ επιλέξτε είδος λογαριασμού!", "OK");
                return;
            }

            if (PasswordEntry.Text != RenterPasswordEntry.Text)
            {
                await DisplayAlert(null, "Οι κωδικοί πρόσβασης δεν ταιριάζουν!", "OK");
                return;
            }

            if (!_suvm.DataService.Init.IsCompleted)
            {
                await DisplayAlert(null, "Παρακαλώ περιμένετε!", "OK");
                return;
            }

            if (_suvm.DataService.Users.Any(x => x.Username == UsernameEntry.Text))
            {
                await DisplayAlert(null, "Το username υπάρχει ήδη!", "OK");
                return;
            }

            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text,
                FirstName = PasswordEntry.Text,
                LastName = LastNameEntry.Text,
                Phone = PhoneEntry.Text,
                Email = EmailEntry.Text,
                UserType = (UserType) RadioGroup.SelectedIndex
            };

            await _suvm.SignUp(user);
            await DisplayAlert(null, "Επιτυχής εγγραφή χρήστη!", "OK");

            await Navigation.PopModalAsync();
        }
    }
}