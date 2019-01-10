using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarlovasiHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedPage : ContentPage
    {
        public FeedPage()
        {
            InitializeComponent();
        }

        private void ApartmentsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ApartmentsListView.SelectedItem = null;
        }
    }
}