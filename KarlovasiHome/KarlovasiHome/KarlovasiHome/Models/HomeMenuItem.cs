namespace KarlovasiHome.Models
{
    public class HomeMenuItem
    {
        public MenuItemType Type { get; set; }
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