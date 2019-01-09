using Microsoft.Azure.Mobile.Server;

namespace karlovasihomeService.DataObjects
{
    public class User : EntityData
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }
        private UserType UserType { get; set; }
    }

    public enum UserType
    {
        Landlord,
        Tenant
    }
}