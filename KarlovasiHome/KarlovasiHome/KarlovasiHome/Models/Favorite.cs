namespace KarlovasiHome.Models
{
    public class Favorite : BaseModel
    {
        private string _userId;
        private string _apartmentId;

        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public string ApartmentId
        {
            get { return _apartmentId; }
            set
            {
                _apartmentId = value;
                OnPropertyChanged(nameof(ApartmentId));
            }
        }
    }
}