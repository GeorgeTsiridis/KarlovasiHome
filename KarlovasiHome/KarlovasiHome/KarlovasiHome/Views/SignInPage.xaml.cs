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
        }

        private async void SignIn_OnClicked(object sender, EventArgs e)
        {
            if (!_sivm.DataService.Init.IsCompleted)
            {
                await DisplayAlert(null, "Παρακαλώ περιμένετε!", "OK");
                return;
            }

            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            
            if (_sivm.SignIn(username, password))
                await Navigation.PushModalAsync(new MainPage());
            else
                await DisplayAlert(null, "Λάθος username ή κωδικός πρόσβασης!", "OK");
        }

        private async void SignUp_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}