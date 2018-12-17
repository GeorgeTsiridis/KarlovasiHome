namespace KarlovasiHome.Models
{
    public class User : BaseModel
    {
        private string _username;
        private string _password;
        private string _name;
        private string _lastName;
        private string _phone;
        private string _email;
        private UserType _userType;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public UserType UserType
        {
            get { return _userType; }
            set
            {
                _userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }
    }

    public enum UserType
    {
        Landlord,
        Tenant
    }
}