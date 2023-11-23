using Microsoft.AspNetCore.Identity;

namespace CatalogAppAPI.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
