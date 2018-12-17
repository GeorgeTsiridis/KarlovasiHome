namespace KarlovasiHome.Models
{
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }

    public enum MenuItemType
    {
        Profile,
        Feed,
        Map,
        Manage,
        Favorites
    }
}