using Microsoft.AspNetCore.Identity;

namespace AuthServer.Data
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
