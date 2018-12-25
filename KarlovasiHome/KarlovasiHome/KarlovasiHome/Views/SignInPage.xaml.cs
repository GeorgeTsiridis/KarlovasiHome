using System;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private BaseViewModel _bvvm;

        public SignInPage()
        {
            InitializeComponent();

            _bvvm = (BaseViewModel) BindingContext;
        }

        protected override async void OnAppearing()
        {
            await _bvvm.DataService.LoadLists();

            UsernameEntry.Text = "";
            PasswordEntry.Text = "";
        }

        private async void SignIn_OnClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            if (_bvvm.DataService.SignIn(username, password))
                await Navigation.PushModalAsync(new MainPage());
            else
                await DisplayAlert(null, "Wrong username or password!", "OK");
        }

        private async void SignUp_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}