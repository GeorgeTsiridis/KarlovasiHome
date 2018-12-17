using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void SignIn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void SignUp_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}