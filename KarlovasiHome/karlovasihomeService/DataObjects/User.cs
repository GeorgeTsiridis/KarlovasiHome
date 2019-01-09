using Microsoft.Azure.Mobile.Server;

namespace KarlovasiHomeService.DataObjects
{
    public class User : EntityData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Landlord,
        Tenant
    }
}