using Microsoft.Azure.Mobile.Server;

namespace KarlovasiHomeService.DataObjects
{
    public class Favorite : EntityData
    {
        public string UserId { get; set; }
        public string ApartmentId { get; set; }
    }
}