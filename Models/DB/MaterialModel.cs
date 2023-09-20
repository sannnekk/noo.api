using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Material")]
    public class MaterialModel : BaseModel
    {
        [Column("subject_id")]
        [Required]
        public Ulid SubjectId { get; set; }
        public SubjectModel? Subject { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Column ("description")]
        public string? Description { get; set; }

        [Column("content")]
        public string? Content { get; set; }
      
        protected override void GenerateSlug()
        {
            // TODO: Implement MaterialModel slug
        }
    }
}
