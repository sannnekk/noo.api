using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    public class ChapterModel : BaseModel
    {
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("course_id")]
        [Required]
        public Ulid CourseId { get; set; }
        public CourseModel? Course { get; set; }

        public List<MaterialModel> Materials { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement ChapterModel slug
        }
    }
}