using Microsoft.AspNetCore.Identity;

namespace fan_07.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}
