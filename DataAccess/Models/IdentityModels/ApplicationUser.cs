using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
    }
}
