using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Material")]
    public class MaterialModel : BaseModel
    {       
        [Column("name")]
        [MaxLength(255)]
        [Required]
        public string? Name { get; set; }

        [Column ("description")]
        [Required]
        public string? Description { get; set; }

        [Column("content")]
        [Required]
        public string? Content { get; set; }

        [Column("chapter_id")]
        [Required]
        public Ulid ChapterId { get; set; }
        public ChapterModel? Chapter { get; set; }

        public List<WorkModel>? Works { get; set; }

        public List<MediaModel>? Media { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement MaterialModel slug
        }
    }
}
