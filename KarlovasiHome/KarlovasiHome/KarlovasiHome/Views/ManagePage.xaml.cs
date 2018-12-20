using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagePage : ContentPage
    {
        public ManagePage()
        {
            InitializeComponent();
        }

        private void Add_OnClicked(object sender, EventArgs e)
        {
            // add apartment page
        }

        private void ApartmentsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ApartmentsListView.SelectedItem = null;
        }
    }
}