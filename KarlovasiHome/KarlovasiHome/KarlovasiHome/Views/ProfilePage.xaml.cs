using System;
using KarlovasiHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfileViewModel _pvm;

        public ProfilePage()
        {
            InitializeComponent();

            _pvm = (ProfileViewModel) BindingContext;
        }

        private void Settings_OnClicked(object sender, EventArgs e)
        {
            _pvm.Enabled = !_pvm.Enabled;
        }

        private void ProfileImage_OnTapped(object sender, EventArgs e)
        {
            
        }
    }
}