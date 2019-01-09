using Microsoft.Azure.Mobile.Server;

namespace karlovasihomeService.DataObjects
{
    public class Favorite : EntityData
    {
        public string UserId { get; set; }
        public string ApartmentId { get; set; }
    }
}