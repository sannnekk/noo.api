using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DB
{
    public class CourseModel : BaseModel
    {
        [Column("name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Column("media_id")]
        [Required]
        public Ulid MediaId { get; set; }
        public MediaModel? Media { get; set; }

        [Column("author_id")]
        [Required]
        public Ulid AuthorId { get; set; }
        public UserModel? Author { get; set; }
       
        public List<ChapterModel>? Chapters { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement CourseModel slug
        }
    }
}