namespace KarlovasiHome.Models
{
    public class Apartment : BaseModel
    {
        private bool _isAvailable;
        private string _userId;
        private string _name;
       /* private Type _type;
        private string _floorArea;
        List Images
        private int rooms;
        price
            year
        perigrafi*/

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                _isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }

        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }
    }
}