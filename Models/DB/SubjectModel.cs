using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Subject")]
    public class SubjectModel : BaseModel
    {
        [Column("name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description {  get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement SubjectModel slug
        }
    }
}
