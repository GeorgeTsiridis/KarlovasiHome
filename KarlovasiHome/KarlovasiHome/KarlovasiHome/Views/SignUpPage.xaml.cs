using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();

         //   this.MyRadioGroup.CheckedChanged += MyRadioGroup_CheckedChanged;
        }

        private async void SignIn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private void SignUp_OnClicked(object sender, EventArgs e)
        {

        }
    }
}