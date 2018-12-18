using System.Collections.Generic;
using Android.Graphics;

namespace KarlovasiHome.Models
{
    public class Apartment : BaseModel
    {
        private string _ownerId;
        private string _name;
        private string _description;
        private double _price;
        private double _floorArea;
        private int _rooms;
        private int _year;
        private bool _isAvailable;
        private RoomType _roomType;
        private List<Bitmap> _images;

        public string OwnerId
        {
            get { return _ownerId; }
            set
            {
                _ownerId = value;
                OnPropertyChanged(nameof(OwnerId));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public double FloorArea
        {
            get { return _floorArea; }
            set
            {
                _floorArea = value;
                OnPropertyChanged(nameof(FloorArea));
            }
        }

        public int Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                _isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }

        public RoomType RoomType
        {
            get { return _roomType; }
            set
            {
                _roomType = value;
                OnPropertyChanged(nameof(RoomType));
            }
        }

        public List<Bitmap> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                OnPropertyChanged(nameof(Images));
            }
        }
    }

    public enum RoomType
    {
        Single,
        Dual,
        Triple
    }
}