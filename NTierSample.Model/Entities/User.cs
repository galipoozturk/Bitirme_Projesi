using NTierSample.Core.Entity;
using NTierSample.Model.Enums;

namespace NTierSample.Model.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            IsActive = false;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }
}
