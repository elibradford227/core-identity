using Microsoft.AspNetCore.Identity;

namespace WebApplication1.models
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
