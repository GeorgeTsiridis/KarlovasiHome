using Newtonsoft.Json;

namespace KarlovasiHome.Models
{
    public class Apartment : BaseModel
    {
        private string _ownerId;
        private string _name;
        private double _latitude;
        private double _longitude;
        private bool _isAvailable;
        private string _address;
        private double _price;
        private double _floorArea;
        private int _rooms;
        private int _year;
        private string _description;
        private RoomType _roomType;

        private string _phone;
        private string _ownerName;
        private bool _isFavorite;

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

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged(nameof(Longitude));
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

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
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

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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

        [JsonIgnore]
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        [JsonIgnore]
        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                _ownerName = value;
                OnPropertyChanged(nameof(OwnerName));
            }
        }

        [JsonIgnore]
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                _isFavorite = value;
                OnPropertyChanged(nameof(IsFavorite));
            }
        }
    }

    public enum RoomType
    {
        Single,
        Dual,
        Triple,
        Other
    }
}