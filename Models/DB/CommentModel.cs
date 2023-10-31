using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Comment")]
    public class CommentModel : BaseModel
    {
        [Column("content")]
        [Required]
        public string Content { get; set; } = string.Empty;

        [Column("score")]
        [Required]
        public int Score { get; set; }

        [Column("task_id")]
        [Required]
        public Ulid TaskId {  get; set; }
        public TaskModel? Task {  get; set; }

        [Column("assigned_work_id")]
        [Required]
        public Ulid AssignedWorkId { get; set; }
        public AssignedWorkModel? AssignedWork { get; set; }

        public List<MediaModel>? Media { get; set; }

        public List<ImageCommentModel>? ImageComments { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement CommentModel slug
        }
    }
}
