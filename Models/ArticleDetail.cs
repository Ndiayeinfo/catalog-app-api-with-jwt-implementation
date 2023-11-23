using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAppAPI.Models
{
    public class ArticleDetail
    {
        [Key]
        public int ArticleId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CodeArticle { get; set; }

        public int Quantite { get; set; }

        public int PrixUnitaire { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Designation { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string DatePeremption { get; set; }
    }
}
