﻿using System;
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

        private async void Add_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewAppartmentPage());
        }

        private void ApartmentsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ApartmentsListView.SelectedItem = null;
        }
    }
}