using System;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private readonly SignInViewModel _sivm;

        public SignInPage()
        {
            InitializeComponent();

            _sivm = (SignInViewModel) BindingContext;
        }

        protected override void OnAppearing()
        {
            UsernameEntry.Text = "";
            PasswordEntry.Text = "";

            while (!_sivm.DataService.Init.IsCompleted)
            {

            }

            Indicator.IsVisible = false;
        }

        private async void SignIn_OnClicked(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;

            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            
            if (await _sivm.SignIn(username, password))
                await Navigation.PushModalAsync(new MainPage());
            else
                await DisplayAlert(null, "Λάθος username ή κωδικός πρόσβασης!", "OK");

            Indicator.IsVisible = false;
        }

        private async void SignUp_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}