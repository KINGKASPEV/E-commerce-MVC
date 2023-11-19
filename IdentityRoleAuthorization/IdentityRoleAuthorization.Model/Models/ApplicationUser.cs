using Microsoft.AspNetCore.Identity;

namespace IdentityRoleAuthorization.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string ProfileProfile { get; set; }
    }
}
