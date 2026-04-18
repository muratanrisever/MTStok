using Microsoft.AspNetCore.Identity;

namespace MTStok.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
