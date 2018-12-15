namespace KarlovasiHome.Models
{
    public class User : BaseModel
    {
        private string _text;
        public string Description { get; set; }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}