using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models.Enums;

namespace api.Models.DB
{
    [Table("Media")]
    public class MediaModel : BaseModel
    {
        [Column("url")]
        [MaxLength(255)]
        [Required]
        public string Url { get; set; } = string.Empty;

        [Column("type")]      
        [Required]
        public MediaType MediaType { get; set; }

        public List<CommentModel>? Comments { get; set; }

        public List<AnswerModel>? Answers { get; set; }

        public List<TaskModel>? Tasks { get; set; }
            
        public List<MaterialModel>? Materials { get; set; }

        public List<ImageCommentModel>? ImageComments { get; set; }

        public List<CourseModel>? Courses { get; set; }

        public List<UserModel>? Users { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement MediaModel slug
        }
    }
}
