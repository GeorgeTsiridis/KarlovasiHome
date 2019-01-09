using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace KarlovasiHome.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        private string _id;

        [JsonProperty("id")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}