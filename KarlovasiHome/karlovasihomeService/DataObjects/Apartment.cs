using Microsoft.Azure.Mobile.Server;

namespace karlovasihomeService.DataObjects
{
    public class Apartment : EntityData
    {
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public double FloorArea { get; set; }
        public int Rooms { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public RoomType RoomType { get; set; }
        //private List<Bitmap> _images;
    }

    public enum RoomType
    {
        Single,
        Dual,
        Triple,
        Other
    }
}