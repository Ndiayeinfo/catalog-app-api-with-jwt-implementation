using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatalogAppAPI.Models.Domain
{
    public class ArticleDetailContext : IdentityDbContext<ApplicationUser>
    {
        public ArticleDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArticleDetail> ArticleDetails { get; set; }

        public DbSet<TokenInfo> TokenInfo { get; set; }
    }
}
